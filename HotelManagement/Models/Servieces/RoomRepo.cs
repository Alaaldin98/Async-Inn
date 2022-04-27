using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Room room = await _context.Rooms.FindAsync(id);
            var hotelroom = await _context.HotelRoom.Where(x => x.HotelId == id).Include(x => x.room)
                .ToListAsync();
            room.room = hotelroom;
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

  

       

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity amenity = new RoomAmenity()
            {
                AmenityID = amenityId,
                RoomID = roomId
            };
            _context.Entry(amenity).State = EntityState.Added; // because we are creating a new one
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var removedAmenity = await _context.RoomAmenities.FirstOrDefaultAsync(i => i.RoomID == roomId && i.AmenityID == amenityId);
            _context.RoomAmenities.Remove(removedAmenity);
            //_context.Entry(removedAmenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
