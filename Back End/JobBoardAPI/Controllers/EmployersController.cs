using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        // GET: api/<EmployersController>
        [HttpGet]
        [Authorize(Policy = "admin")]
        public IEnumerable<Employer> GetEmployers()
        {
            return _dbContext.Employers;
        }

        // GET api/<EmployersController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,employer")]
        public IActionResult GetEmployerById(int id)
        {
            var employer = _dbContext.Employers.FirstOrDefault(x => x.Id == id);
            if (employer == null)
            {
                return NotFound();
            }
            return Ok(employer);
        }

        // POST api/<EmployersController>
        [HttpPost]
        [Authorize(Roles = "admin,employer")]
        public void Post([FromBody] Employer employer)
        {
            _dbContext.Employers.Add(employer);
            _dbContext.SaveChanges();
        }

        // PUT api/<EmployersController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,employer")]
        public IActionResult Put(int id, [FromBody] Employer value)
        {
            var employer = _dbContext.Employers.Find(id);
            if (employer == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            employer.CompanyName = value.CompanyName;
            employer.ContactName = value.ContactName;
            employer.ContactEmail = value.ContactEmail;
            employer.ContactPhone = value.ContactPhone;
            
            _dbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<EmployersController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult Delete(int id)
        {
            var employer = _dbContext.Employers.Find(id);
            if (employer == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            _dbContext.Employers.Remove(employer);
            _dbContext.SaveChanges();
            return Ok("Record Deleted");
        }
    }
}
