using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.DTO
{
    public class LoginData
    {
        [Required(ErrorMessage = "The Username is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The password is required!")]
        public string Password { get; set; }
    }
}
