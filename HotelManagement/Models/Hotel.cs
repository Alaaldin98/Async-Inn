using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Country { get; set; }
        public List<HotelRoom> hotelrooms { get; set; }
        public string City { get; internal set; }
        public string State { get; internal set; }
    }
}
