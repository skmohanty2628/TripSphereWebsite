using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TripSphere.Controllers
{
    public class RecommendController : Controller
    {
        public IActionResult Places(string destination)
        {
            var recommendations = new Dictionary<string, List<string>>
            {
                { "Australia", new List<string> {
                    "Sydney Opera House", "Great Barrier Reef", "Bondi Beach", "Uluru (Ayers Rock)", "Blue Mountains National Park"
                }},
                { "Paris", new List<string> {
                    "Eiffel Tower", "Louvre Museum", "Notre-Dame Cathedral", "Champs-Élysées", "Montmartre"
                }},
                { "USA", new List<string> {
                    "Statue of Liberty", "Grand Canyon", "Times Square", "Yellowstone National Park", "Golden Gate Bridge"
                }},
                { "Dubai", new List<string> {
                    "Burj Khalifa", "Desert Safari", "Dubai Marina", "The Dubai Mall", "Palm Jumeirah"
                }},
                { "Italy", new List<string> {
                    "Colosseum (Rome)", "Leaning Tower of Pisa", "Venice Canals", "Amalfi Coast", "Vatican City"
                }},
                { "Greece", new List<string> {
                    "Santorini", "Acropolis of Athens", "Mykonos", "Delphi", "Mount Olympus"
                }},
                { "India", new List<string> {
                    "Taj Mahal", "Jaipur (Pink City)", "Kerala Backwaters", "Goa Beaches", "Himalayan Ranges"
                }},
                { "Japan", new List<string> {
                    "Mount Fuji", "Tokyo Tower", "Kyoto Temples", "Osaka Castle", "Nara Deer Park"
                }},
                { "China", new List<string> {
                    "Great Wall of China", "Forbidden City", "Terracotta Army", "The Bund (Shanghai)", "Li River Cruise"
                }},
                { "London", new List<string> {
                    "London Eye", "Buckingham Palace", "Tower of London", "British Museum", "Big Ben"
                }},
            };

            ViewBag.Destination = destination;

            if (recommendations.ContainsKey(destination))
            {
                ViewBag.Places = recommendations[destination];
            }
            else
            {
                ViewBag.Places = new List<string> { "Explore local attractions and hidden gems!" };
            }

            return View();
        }
    }
}

