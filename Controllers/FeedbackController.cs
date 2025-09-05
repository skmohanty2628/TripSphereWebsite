using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripSphere.Data;
using TripSphere.Models;
using System.Threading.Tasks;
using System.Linq;

namespace TripSphere.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly TripsphereDbContext _context;

        public FeedbackController(TripsphereDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var feedbacks = await _context.Feedback
                .Include(f => f.User)
                .OrderByDescending(f => f.Id)
                .ToListAsync();

            ViewBag.FeedbackList = feedbacks;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(TravelFeedback feedback)
        {
            // 🔐 Get user based on logged-in email
            var email = User.Identity?.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                feedback.UserId = 1;
            }
            else
            {
                // fallback or handle error
                feedback.UserId = 1; // optional: fallback to test user
            }

            if (ModelState.IsValid)
            {
                _context.Feedback.Add(feedback);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Thank you for your feedback!";
                return RedirectToAction("Index");
            }

            ViewBag.FeedbackList = await _context.Feedback
                .Include(f => f.User)
                .OrderByDescending(f => f.Id)
                .ToListAsync();

            return View("Index", feedback);
        }
    }
}
