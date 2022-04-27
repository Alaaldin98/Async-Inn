﻿using System.Collections.Generic;
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
        public string Layout { get; set; }
        public List<HotelRoom> room { get; set; }
        public List<RoomAmenities> roomamenity { get; set; }
    }
}
