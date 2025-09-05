using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripSphere.Data;
using TripSphere.Models;

namespace TripSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPlansController : ControllerBase
    {
        private readonly TripsphereDbContext _context;

        public TravelPlansController(TripsphereDbContext context)
        {
            _context = context;
        }

        // GET: api/TravelPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelPlan>>> Get()
        {
            return await _context.TravelPlan.Include(p => p.TravelMode).ToListAsync();
        }

        // GET: api/TravelPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelPlan>> Get(int id)
        {
            var plan = await _context.TravelPlan.Include(p => p.TravelMode).FirstOrDefaultAsync(p => p.Id == id);
            if (plan == null)
                return NotFound();

            return Ok(plan);
        }

        // POST: api/TravelPlans
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TravelPlan plan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.TravelPlan.Add(plan);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = plan.Id }, plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error: {ex.Message}");
            }
        }

        // PUT: api/TravelPlans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TravelPlan updatedPlan)
        {
            if (id != updatedPlan.Id)
                return BadRequest("ID mismatch");

            _context.Entry(updatedPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TravelPlan.Any(p => p.Id == id))
                    return NotFound();

                throw;
            }
        }

        // DELETE: api/TravelPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var plan = await _context.TravelPlan.FindAsync(id);
            if (plan == null)
                return NotFound();

            _context.TravelPlan.Remove(plan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
