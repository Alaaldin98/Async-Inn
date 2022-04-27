using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{

    public class HotelRoom
    {
       
        public int HotelId { get; set; }
        [Required]
        public int RoomNumber { get; set; }
       
        public int RoomID { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public bool PetFriendly { get; set; }

        public Hotel hotel { get; set; }
        public Room room { get; set; }
    }
}
