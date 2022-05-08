using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.DTO
{
    public class RegisterUserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Gender { get; set; }
    }
}
