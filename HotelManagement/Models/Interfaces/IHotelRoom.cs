using HotelManagement.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoomDTO> Create(int id, HotelRoomDTO hotelroom);
        Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId);
        Task<HotelRoom> GetHotelRoom(int id, int roomNumber);
        Task<HotelRoomDTO> UpdateHotelRoom(int id, int roomNumber, HotelRoomDTO hotelroom);
        Task Delete(int id, int roomNumber);
    }
}
