namespace TripSphere.Models
{
    public class TripModel
    {
        public int Id { get; set; }

        public string? Destination { get; set; }
        public string? Country { get; set; }
        public string? Duration { get; set; }
        public string? Budget { get; set; }
        public string? Mode { get; set; }

        public bool IsBooked { get; set; } = false; // ✅ NEW
    }
}
