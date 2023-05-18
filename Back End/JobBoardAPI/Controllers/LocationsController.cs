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
        [Authorize]
        public IEnumerable<Location> Get()
        {
            return _dbContext.Locations;
        }

        // GET api/<LocationsController>/5
        [HttpGet("{id}")]
        public Location Get(int id)
        {
            return _dbContext.Locations.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<LocationsController>
        [HttpPost]
        public void Post([FromBody] Location location)
        {
            _dbContext.Locations.Add(location);
            _dbContext.SaveChanges();
        }

        // PUT api/<LocationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Location value)
        {
            var location = _dbContext.Locations.Find(id);
            location.City = value.City;
            location.State = value.State;
            location.Country = value.Country;
            _dbContext.SaveChanges();
        }

        // DELETE api/<LocationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var location = _dbContext.Locations.Find(id);
            _dbContext.Locations.Remove(location);
            _dbContext.SaveChanges();
        }
    }
}
