using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripSphere.Data;
using TripSphere.Models;
using Microsoft.AspNetCore.Authorization;

namespace TripSphere.Controllers
{
    public class TripsController : Controller
    {
        private readonly TripsphereDbContext _context;

        public TripsController(TripsphereDbContext context)
        {
            _context = context;
        }

        // ✅ Public GET: anyone can see the Book page
        [HttpGet]
        public async Task<IActionResult> Book()
        {
            var trips = await _context.TripModels.ToListAsync();
            return View(trips);
        }

        // ✅ Require login to actually book a trip
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(TripModel newTrip)
        {
            if (ModelState.IsValid)
            {
                _context.TripModels.Add(newTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction("Book");
            }
            return View(newTrip);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var trip = await _context.TripModels.FindAsync(id);
            return trip == null ? NotFound() : View(trip);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TripModel updatedTrip)
        {
            if (id != updatedTrip.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(updatedTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction("Book");
            }

            return View(updatedTrip);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _context.TripModels.FindAsync(id);
            if (trip == null)
                return NotFound();

            _context.TripModels.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction("Book");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Analytics()
        {
            var trips = await _context.TripModels.ToListAsync();
            return View(trips);
        }
    }
}
