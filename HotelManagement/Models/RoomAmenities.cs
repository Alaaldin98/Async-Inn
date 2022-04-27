using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    
    public class RoomAmenities
    {
      
        public int AmenitiesId { get; set; }
       
        public int RoomID { get; set; }

        public Room room { get; set; }
        public Amenity amenity { get; set; }
    }
}
