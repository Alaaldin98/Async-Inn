using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelroom);
        Task<List<HotelRoom>> GetHotelRooms();
        Task<HotelRoom> GetHotelRoom(int id);
        Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom hotelroom);
        Task Delete(int id);
    }
}
