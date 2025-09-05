using System.ComponentModel.DataAnnotations;

namespace TripSphere.Models
{
    public class LoginModel
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        public LoginModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
