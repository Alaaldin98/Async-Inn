using HotelManagement.Models.DTO;
using System;
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
        public string layout { get; set; }
        public List<HotelRoom> hotelrooms { get; set; }
        public List<RoomAmenities> roomamenity { get; set; }
       
    }
}
