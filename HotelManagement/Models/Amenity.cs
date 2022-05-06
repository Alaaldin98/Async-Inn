using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Amenity
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<RoomAmenities> amenity { get; set; }
    }
}
