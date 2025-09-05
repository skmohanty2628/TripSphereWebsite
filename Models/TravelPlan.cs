using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripSphere.Models
{
    public class TravelPlan
    {
        [Key]
        public int Id { get; set; }

        public string? Destination { get; set; }
        public string? Country { get; set; }
        public string? Duration { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Budget { get; set; }

        // Foreign Key to TravelMode
        public int? TravelModeId { get; set; }

        [ForeignKey("TravelModeId")]
        public TravelMode? TravelMode { get; set; }
    }
}
