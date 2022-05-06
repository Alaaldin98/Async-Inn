using HotelManagement.Data;
using HotelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HotelManagement.Models.Servieces
{
    public class RoomRepo : IRoom
    {
        private readonly AsyncInnDbContext _context;
        public RoomRepo(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }




        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms
                                  .Include(a => a.roomamenity)
                                  .ThenInclude(b => b.amenity)
                                  .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms
                              .Include(a => a.roomamenity)
                              .ThenInclude(b => b.amenity)
                              .ToListAsync();
        }
        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities amenity = new RoomAmenities()
            {
                AmenitiesId = amenityId,
                RoomID = roomId
            };
            _context.Entry(amenity).State = EntityState.Added; // because we are creating a new one
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var removedAmenity = await _context.RoomAmenities.FirstOrDefaultAsync(i => i.RoomID == roomId && i.AmenitiesId == amenityId);
            _context.RoomAmenities.Remove(removedAmenity);
            //_context.Entry(removedAmenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            throw new System.NotImplementedException();
        }
    }
}
