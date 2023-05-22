using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        // GET: api/<JobsController>
        [HttpGet]
        [Authorize(Roles = "admin,employer,applicant")]
        public IEnumerable<Job> GetJobs()
        {
            return _dbContext.Jobs;
        }

        // GET api/<JobsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,employer,applicant")]
        public IActionResult GetJobById(int id)
        {
            var job = _dbContext.Jobs.FirstOrDefault(x => x.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        // POST api/<JobsController>
        [HttpPost]
        [Authorize(Roles = "admin,employer")]
        public void Post([FromBody] Job job)
        {
            _dbContext.Jobs.Add(job);
            _dbContext.SaveChanges();
        }

        // PUT api/<JobsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,employer")]
        public IActionResult Put(int id, [FromBody] Job value)
        {
            var job = _dbContext.Jobs.Find(id);
            if (job == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            job.Title = value.Title;
            job.Description = value.Description;
            job.JobType = value.JobType;
            job.Salary = value.Salary;
            job.CategoryId = value.CategoryId;
            job.SkillId = value.SkillId;
            job.LocationId = value.LocationId;

            _dbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<JobsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,employer")]
        public IActionResult Delete(int id)
        {
            var job = _dbContext.Jobs.Find(id);
            if (job == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            _dbContext.Jobs.Remove(job);
            _dbContext.SaveChanges();
            return Ok("Record Deleted");
        }
    }
}
