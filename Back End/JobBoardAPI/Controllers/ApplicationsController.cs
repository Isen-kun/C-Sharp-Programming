using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JobBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ApplicationsController(ApiDbContext dbContext, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
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
                    // Return the static serve link for the file
                    ResumeUrl = GetResumeUrl(application.Resume) // Custom method to get the static serve link
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

            var transformedApplication = new
            {
                application.Id,
                application.UserId,
                application.JobId,
                application.Status,
                application.AppliedAt,
                // Return the static serve link for the file
                ResumeUrl = GetResumeUrl(application.Resume) // Custom method to get the static serve link
            };

            return Ok(transformedApplication);
        }


        // GET api/<ApplicationsController>/5
        [HttpGet("AppResume/{id}")]
        [Authorize(Roles = "admin,employer,applicant")]
        public IActionResult GetApplicationResumeById(int id)
        {
            var application = _dbContext.Applications.FirstOrDefault(x => x.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            // Return the file directly without changing the implementation
            var filePath = application.Resume;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var contentType = "application/pdf"; // Set the content type according to your file type

            return new FileStreamResult(fileStream, contentType);
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

            // Determine the appropriate path to store the file
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
            //var resumeFolderPath = _configuration["AppSettings:ResumeFolderPath"];
            var resumeFileName = Path.GetFileName(resumePath);
            var resumeUrlPath = $"assets/{resumeFileName}";

            return $"{baseUrl}/{resumeUrlPath}";
        }
    }
}