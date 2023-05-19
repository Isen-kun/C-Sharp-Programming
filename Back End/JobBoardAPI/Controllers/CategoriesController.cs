using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        // GET: api/<CategoriesController>
        [HttpGet]
        [Authorize(Policy = "admin")]
        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        [Authorize(Policy = "admin")]
        public void Post([FromBody] Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult Put(int id, [FromBody] Category value)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            category.Name = value.Name;
            category.Description = value.Description;
            _dbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return Ok("Record Deleted");
        }
    }

}
