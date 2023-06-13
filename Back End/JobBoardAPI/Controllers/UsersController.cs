using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();
        private IConfiguration _config;

        public UsersController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Authorize(Policy = "admin")]
        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users;
        }

        [HttpPost("[action]")]
        public IActionResult RegisterEmployer([FromBody] User user)
        {
            var userExists = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userExists != null)
            {
                return BadRequest("User with same email already exists");
            }

            user.RoleId = 2;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPost("[action]")]
        public IActionResult RegisterApplicant([FromBody] User user)
        {
            var userExists = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userExists != null)
            {
                return BadRequest("User with same email already exists");
            }

            user.RoleId = 3;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPost("[action]")]
        public IActionResult Login([FromBody] User user)
        {
            var currentUser = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (currentUser == null)
            {
                return NotFound();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            string roleName="";
            foreach(var role in _dbContext.Roles)
            {
                if(role.Id == currentUser.RoleId)
                {
                    roleName = role.RoleName; 
                    break;
                }
            }

            var userTypeClaim = new Claim("userType", roleName); // Add user type claim
            var emailClaim = new Claim(ClaimTypes.Email, user.Email);;

            var claims = new[]
            {
                userTypeClaim,
                emailClaim
            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwt);
        }

        //[HttpPost("[action]")]
        //public IActionResult Logout()
        //{
        //    // Invalidate the token by setting its expiration time to a past date/time
        //    var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        //    var jwtHandler = new JwtSecurityTokenHandler();
        //    var jwtToken = jwtHandler.ReadToken(token) as JwtSecurityToken;

        //    var expiredToken = new JwtSecurityToken(
        //    _config["JWT:Issuer"],
        //    _config["JWT:Audience"],
        //    jwtToken.Claims,
        //    DateTime.Now,
        //    DateTime.Now.AddMinutes(-60),  // Expired token with negative expiration time
        //    jwtToken.SigningCredentials
        //    );

        //    var newToken = jwtHandler.WriteToken(expiredToken);

        //    return Ok("Logout successful");
        //}
    }
}
