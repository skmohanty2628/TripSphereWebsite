using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TripSphere.Models;
using TripSphere.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TripSphere.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TripsphereDbContext _context;

        public HomeController(ILogger<HomeController> logger, TripsphereDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() => View();

        public IActionResult About() => View();

        public IActionResult Privacy() => View();

        // ✅ GET: Show the contact form
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        // ✅ POST: Handle contact form submission
        [HttpPost]
        public async Task<IActionResult> Contact(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                message.SubmittedOn = DateTime.Now;
                _context.ContactMessages.Add(message); // If your DbSet is plural, use _context.ContactMessages
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Thank you, {message.Name}! Your message was received.";
                return RedirectToAction("Contact");
            }

            return View(message);
        }

        // ✅ POST: Delete a message by ID
        [HttpPost]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _context.ContactMessages.FindAsync(id);
            if (message != null)
            {
                _context.ContactMessages.Remove(message);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Message deleted successfully.";
            }
            return RedirectToAction("Messages");
        }

        // ✅ GET: List all messages
        public async Task<IActionResult> Messages()
        {
            var messages = await _context.ContactMessages.ToListAsync();
            return View(messages);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}