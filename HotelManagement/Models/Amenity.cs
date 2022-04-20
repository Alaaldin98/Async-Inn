using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
