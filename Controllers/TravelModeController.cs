using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripSphere.Data;
using TripSphere.Models;

namespace TripSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelModesController : ControllerBase
    {
        private readonly TripsphereDbContext _context;
        public TravelModesController(TripsphereDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelMode>>> Get() =>
            await _context.TravelMode.ToListAsync();
    }

}
    
