using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(int id, HotelRoom hotelroom);
        Task<List<HotelRoom>> GetHotelRooms();
        Task<HotelRoom> GetHotelRoom(int id, int roomNumber);
        Task<HotelRoom> UpdateHotelRoom(int id, int roomNumber, HotelRoom hotelroom);
        Task Delete(int id, int roomNumber);
    }
}
