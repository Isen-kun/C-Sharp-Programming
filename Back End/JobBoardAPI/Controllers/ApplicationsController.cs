using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        private IConfiguration _configuration;

        public ApplicationsController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/<ApplicationsController>
        [HttpGet]
        [Authorize(Roles = "admin,employer,applicant")]
        public IActionResult GetApplications()
        {
            var applications = _dbContext.Applications.ToList();

            // Transform the applications data if needed
            var transformedApplications = applications.Select(application =>
            {
                // Map the relevant properties
                return new
                {
                    application.Id,
                    application.UserId,
                    application.JobId,
                    application.Status,
                    application.AppliedAt,
                    // Return the file path or URL to the React application
                    ResumeUrl = GetResumeUrl(application.Resume) // Custom method to get the file URL
                };
            });

            return Ok(transformedApplications);
        }

        // GET api/<ApplicationsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,employer,applicant")]
        public IActionResult GetApplicationById(int id)
        {
            var application = _dbContext.Applications.FirstOrDefault(x => x.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            // Retrieve the file path from the Resume property
            var filePath = application.Resume;

            // Check if the file exists
            if (System.IO.File.Exists(filePath))
            {
                // Read the file content and return as a FileStreamResult
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var contentType = "application/pdf"; // Set the content type according to your file type

                return new FileStreamResult(fileStream, contentType);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<ApplicationsController>
        [HttpPost]
        [Authorize(Roles = "admin,applicant")]
        public IActionResult Post(IFormFile file, [FromForm] Application application)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            var resumeFolderPath = _configuration["AppSettings:ResumeFolderPath"];
            var resumeFileName = Guid.NewGuid().ToString() + ".pdf";
            var resumeFilePath = Path.Combine(resumeFolderPath, resumeFileName);

            using (var fileStream = new FileStream(resumeFilePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            application.Resume = resumeFilePath;

            _dbContext.Applications.Add(application);
            _dbContext.SaveChanges();

            return Ok("Application submitted successfully");
        }

        // PUT api/<ApplicationsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,employer")]
        public IActionResult Put(int id, IFormFile file, [FromForm] Application updatedApplication)
        {
            var application = _dbContext.Applications.Find(id);
            if (application == null)
            {
                return NotFound("No records found with this id: " + id);
            }

            if (file != null)
            {
                // Delete the old resume file
                if (System.IO.File.Exists(application.Resume))
                {
                    System.IO.File.Delete(application.Resume);
                }

                // Save the new resume file
                var resumeFolderPath = _configuration["AppSettings:ResumeFolderPath"];
                var resumeFileName = Guid.NewGuid().ToString() + ".pdf";
                var resumeFilePath = Path.Combine(resumeFolderPath, resumeFileName);

                using (var fileStream = new FileStream(resumeFilePath, FileMode.Create))
                {
                    // Copy the file content to the file stream
                    file.CopyTo(fileStream);
                }

                application.Resume = resumeFilePath;
            }

            application.Status = updatedApplication.Status;
            application.AppliedAt = updatedApplication.AppliedAt;

            _dbContext.SaveChanges();

            return Ok("Record updated successfully");
        }



        // DELETE api/<ApplicationsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,employer,applicant")]
        public IActionResult Delete(int id)
        {
            var application = _dbContext.Applications.Find(id);
            if (application == null)
            {
                return NotFound("No records found with this id: " + id);
            }

            // Delete the resume file
            if (System.IO.File.Exists(application.Resume))
            {
                System.IO.File.Delete(application.Resume);
            }

            _dbContext.Applications.Remove(application);
            _dbContext.SaveChanges();

            return Ok("Record deleted");
        }

        private string GetResumeUrl(string resumePath)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            // Determine the URL path to the resume file
            var resumeFolderPath = _configuration["AppSettings:ResumeFolderPath"];
            var resumeUrlPath = resumePath.Replace(resumeFolderPath, "").Replace("\\", "/").TrimStart('/');

            return $"{baseUrl}/{resumeUrlPath}";
        }
    }
}
