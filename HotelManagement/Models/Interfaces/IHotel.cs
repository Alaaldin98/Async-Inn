using HotelManagement.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Models.Interfaces
{
    public interface IHotel
    {
       Task<HotelDTO> Create(HotelDTO hotel);
        Task<List<HotelDTO>> GetHotels();
        Task<HotelDTO> GetHotel(int id);
        Task<Hotel> UpdateHotel (int id,Hotel hotel);
        Task Delete(int id);

    }
}
