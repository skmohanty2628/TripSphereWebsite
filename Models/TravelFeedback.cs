using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripSphere.Models
{
    public class TravelFeedback
    {
        public int Id { get; set; }

        [Required]
        public string? Message { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
