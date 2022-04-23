using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Models.Interfaces
{
    public interface IRoomAmenities
    {
        Task<RoomAmenities> Create(RoomAmenities roomamenities);
        Task<List<RoomAmenities>> GetRoomAmenities();
        Task<RoomAmenities> GetRoomAmenity(int id);
        Task<RoomAmenities> UpdateRoomAmenities(int id, RoomAmenities roomamenities);
        Task Delete(int id);
    }
}
