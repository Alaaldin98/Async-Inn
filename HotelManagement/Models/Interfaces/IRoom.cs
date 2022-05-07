using HotelManagement.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HotelManagement.Models.Interfaces
{
    public interface IRoom
    {
        Task<RoomDTO> Create(RoomDTO room);
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> GetRoom(int id);
        Task<RoomDTO> UpdateRoom(int id, RoomDTO room);
        Task Delete(int id);
        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
