using HotelManagement.Data;
using HotelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Models.Servieces
{
    public class RoomAmenitiesRepo : IRoomAmenities
    {
        private readonly AsyncInnDbContext _context;

        public RoomAmenitiesRepo(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<RoomAmenities> Create(RoomAmenities roomamenities)
        {
            _context.Entry(roomamenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return roomamenities;
        }

        public async Task<List<RoomAmenities>> GetRoomAmenities()
        {
            var roomAmenities = await _context.RoomAmenities.ToListAsync();
            return roomAmenities;
        }

        public async Task<RoomAmenities> GetRoomAmenity(int id)
        {
            var roomamenity = await _context.RoomAmenities.FindAsync(id);
            return roomamenity;
        }

        public async Task<RoomAmenities> UpdateRoomAmenities(int id, RoomAmenities roomamenities)
        {
            _context.Entry(roomamenities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return roomamenities;
        }
        public async Task Delete(int id)
        {
            RoomAmenities roomamenities = await GetRoomAmenity(id);
            _context.Entry(roomamenities).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
