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

        // GET: api/<ApplicationsController>
        [HttpGet]
        [Authorize(Roles = "admin,employer,applicant")]
        public IEnumerable<Application> GetApplications()
        {
            return _dbContext.Applications;
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
            return Ok(application);
        }

        // POST api/<ApplicationsController>
        [HttpPost]
        [Authorize(Roles = "admin,applicant")]
        public void Post([FromBody] Application application)
        {
            _dbContext.Applications.Add(application);
            _dbContext.SaveChanges();
        }

        // PUT api/<ApplicationsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,employer")]
        public IActionResult Put(int id, [FromBody] Application value)
        {
            var application = _dbContext.Applications.Find(id);
            if (application == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            application.Status = value.Status;
            application.AppliedAt = value.AppliedAt;
            application.Resume = value.Resume;

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
                return NotFound("No records found with this id + " + id);
            }
            _dbContext.Applications.Remove(application);
            _dbContext.SaveChanges();
            return Ok("Record Deleted");
        }
    }
}
