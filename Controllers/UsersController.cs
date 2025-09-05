using Microsoft.AspNetCore.Mvc;
using TripSphere.Data;
using TripSphere.Models;

namespace TripSphere.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly TripsphereDbContext _context;

        public UsersController(TripsphereDbContext context)
        {
            _context = context;
        }

        // ✅ Register a new user
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            var existing = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existing != null)
            {
                return BadRequest("User already exists.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Registration successful.");
        }

        // ✅ Log in user (check credentials)
        [HttpGet("login")]
        public IActionResult Login(LoginModel credentials)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == credentials.Email && u.Password == credentials.Password);

            if (user == null)
                return Unauthorized("Invalid email or password.");

            return Ok(new
            {
                user.UserId,
                user.Username,
                user.Email
            });
        }
    }
}
