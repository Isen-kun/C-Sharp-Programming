using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        // GET: api/<SkillsController>
        [HttpGet]
        [Authorize(Policy = "admin")]
        public IEnumerable<Skill> GetSkills()
        {
            return _dbContext.Skills;
        }

        // GET api/<SkillsController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult GetSKillById(int id)
        {
            var skill = _dbContext.Skills.FirstOrDefault(x => x.Id == id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        // POST api/<SkillsController>
        [HttpPost]
        [Authorize(Policy = "admin")]
        public void Post([FromBody] Skill skill)
        {
            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();
        }

        // PUT api/<SkillsController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult Put(int id, [FromBody] Skill value)
        {
            var skill = _dbContext.Skills.Find(id);
            if (skill == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            skill.Name = value.Name;
            skill.Description = value.Description;
            _dbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<SkillssController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult Delete(int id)
        {
            var skill = _dbContext.Skills.Find(id);
            if (skill == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            _dbContext.Skills.Remove(skill);
            _dbContext.SaveChanges();
            return Ok("Record Deleted");
        }
    }
}
