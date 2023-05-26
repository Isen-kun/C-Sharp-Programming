using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //// GET api/<JobsController>/category/{category}
        //[HttpGet("category/{category}")]
        //[Authorize(Roles = "admin,applicant")]
        //public IActionResult GetJobsByCategory(string category)
        //{
        //    var jobs = _dbContext.Jobs
        //    .Include(j => j.Category)
        //    .Where(j => j.Category.Name.ToLower() == category.ToLower())
        //    .ToList();

        //    //List<Job> jobs = new List<Job>();
        //    //foreach (var cate in _dbContext.Categories)
        //    //{
        //    //    if (category == cate.Name)
        //    //    {
        //    //        foreach(var job in GetJobs())
        //    //        {
        //    //            if(job.CategoryId == cate.Id)
        //    //            {
        //    //                jobs.Add(job);
        //    //            }
        //    //        }
        //    //    }
        //    //}


        //    if (jobs.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(jobs);
        //}

        //// GET api/<JobsController>/location/{location}
        //[HttpGet("location/{location}")]
        //[Authorize(Roles = "admin,applicant")]
        //public IActionResult GetJobsByLocation(string location)
        //{
        //    var jobs = _dbContext.Jobs
        //    .Include(j => j.Location)
        //    .Where(j => j.Location.City.ToLower() == location.ToLower()
        //            || j.Location.State.ToLower() == location.ToLower()
        //            || j.Location.Country.ToLower() == location.ToLower())
        //    .ToList();

        //    //List<Job> jobs = new List<Job>();
        //    //foreach (var loc in _dbContext.Locations)
        //    //{
        //    //    if (location == loc.City || location == loc.State || location == loc.Country)
        //    //    {
        //    //        foreach (var job in GetJobs())
        //    //        {
        //    //            if (job.CategoryId == loc.Id)
        //    //            {
        //    //                jobs.Add(job);
        //    //            }
        //    //        }
        //    //    }
        //    //}

        //    if (jobs.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(jobs);
        //}

        //// GET api/<JobsController>/skill/{skill}
        //[HttpGet("skill/{skill}")]
        //[Authorize(Roles = "admin,applicant")]
        //public IActionResult GetJobsBySkill(string skill)
        //{
        //    var jobs = _dbContext.Jobs
        //    .Include(j => j.Skill)
        //    .Where(j => j.Skill.Name.ToLower() == skill.ToLower())
        //    .ToList();

        //    //List<Job> jobs = new List<Job>();
        //    //foreach (var ski in _dbContext.Skills)
        //    //{
        //    //    if (skill == ski.Name)
        //    //    {
        //    //        foreach (var job in GetJobs())
        //    //        {
        //    //            if (job.SkillId == ski.Id)
        //    //            {
        //    //                jobs.Add(job);
        //    //            }
        //    //        }
        //    //    }
        //    //}

        //    if (jobs.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(jobs);
        //}

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
