using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripSphere.Data;
using TripSphere.Models;
using System.Threading.Tasks;
using System.Linq;

namespace TripSphere.Controllers
{
    public class AnalyticsController : Controller
    {
        private readonly TripsphereDbContext _context;

        public AnalyticsController(TripsphereDbContext context)
        {
            _context = context;
        }
        

        public async Task<IActionResult> Index()
        {
            var plans = await _context.TravelPlan
                .Include(tp => tp.TravelMode)
                .ToListAsync();

            return View("Analytics", plans);
        }
    }
}
