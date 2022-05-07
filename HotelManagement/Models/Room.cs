using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Layout layout { get; set; }
        public List<HotelRoom> room { get; set; }
        public List<RoomAmenities> roomamenity { get; set; }
        public enum Layout
        {
            studio,
            onebedroom,
            twobedroom
        }
    }
}
