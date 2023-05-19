using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        // GET: api/<LocationsController>
        [HttpGet]
        [Authorize(Policy = "admin")]
        public IEnumerable<Location> GetLocations()
        {
            return _dbContext.Locations;
        }

        // GET api/<LocationsController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult GetLocationById(int id)
        {
            var location = _dbContext.Locations.FirstOrDefault(x => x.Id == id);
            if(location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // POST api/<LocationsController>
        [HttpPost]
        [Authorize(Policy = "admin")]
        public void Post([FromBody] Location location)
        {
            _dbContext.Locations.Add(location);
            _dbContext.SaveChanges();
        }

        // PUT api/<LocationsController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult Put(int id, [FromBody] Location value)
        {
            var location = _dbContext.Locations.Find(id);
            if(location == null)
            {
                return NotFound("No records found with this id + " +  id);
            }
            location.City = value.City;
            location.State = value.State;
            location.Country = value.Country;
            _dbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<LocationsController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult Delete(int id)
        {
            var location = _dbContext.Locations.Find(id);
            if(location == null)
            {
                return NotFound("No records found with this id + " + id);
            }
            _dbContext.Locations.Remove(location);
            _dbContext.SaveChanges();
            return Ok("Record Deleted");
        }
    }
}
