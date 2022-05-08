using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Gender { get; set; }

    }
}
