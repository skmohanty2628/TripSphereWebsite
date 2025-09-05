using Microsoft.AspNetCore.Mvc;
using TripSphere.Data;
using TripSphere.Models;
using System;
using System.Threading.Tasks;

namespace TripSphere.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactMessagesController : ControllerBase
    {
        private readonly TripsphereDbContext _context;

        public ContactMessagesController(TripsphereDbContext context)
        {
            _context = context;
        }

        // POST: api/contactmessages
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactMessage message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            message.SubmittedOn = DateTime.Now;

            _context.ContactMessages.Add(message);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
