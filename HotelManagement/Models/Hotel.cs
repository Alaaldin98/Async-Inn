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
        public string Address { get; set; }
        [Required]
        public double Phone { get; set; }

        public List<HotelRoom> hotel { get; set; }

    }
}
