using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Models.Interfaces
{
    public interface IHotel
    {
       Task<Hotel> Create(Hotel hotel);
        Task<List<Hotel>> GetHotels();
        Task<Hotel> GetHotel(int id);
        Task<Hotel> UpdateHotel (int id,Hotel hotel);
        void DeleteHotel(int id);

    }
}
