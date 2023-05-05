using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Data;
using RealEstateAPI.Models;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();


        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _dbContext.Categories;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x=>x.Id==id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        //api/<CategoriesController>/GetSortedCategories
        [HttpGet("[action]")]
        public IActionResult GetSortedCategories()
        {
            return Ok(_dbContext.Categories.OrderByDescending(x => x.Name));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category categoryObj)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound("No records found with tis Id " + id);
            }
            category.Name = categoryObj.Name;
            category.ImageUrl = categoryObj.ImageUrl;
            _dbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound("No records found with tis Id " + id);
            }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return Ok("Record deletd");
        }
    }
}
