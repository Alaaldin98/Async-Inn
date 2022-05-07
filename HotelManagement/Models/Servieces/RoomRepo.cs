using HotelManagement.Data;
using HotelManagement.Models.DTO;
using HotelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HotelManagement.Models.Room;

namespace HotelManagement.Models.Servieces
{
    public class RoomRepo : IRoom
    {
        private readonly AsyncInnDbContext _context;
        public RoomRepo(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<RoomDTO> Create(RoomDTO room)
        {
            Room room1 = new Room
            {
                Id = room.ID,
                Name = room.Name,
                layout = room.Layout
            };
            _context.Entry(room1).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<RoomDTO> GetRoom(int id)
        {
            return await _context.Rooms

              .Select(room => new RoomDTO
              {
                  ID = id,
                  Name = room.Name,
                  Layout = room.layout.ToString(),
                  Amenities = room.roomamenity
                   .Select(amenity => new AmenityDTO
                   {
                       ID = id,
                       Name = amenity.room.Name,
                   }).ToList()
              }).FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _context.Rooms

                .Select(room => new RoomDTO
                {
                    ID = room.Id,
                    Name = room.Name,
                    Layout = room.layout.ToString(),
                    Amenities = room.roomamenity
                     .Select(amenity => new AmenityDTO
                     {
                         ID = amenity.AmenitiesId,
                         Name = amenity.room.Name,
                     }).ToList()
                }).ToListAsync();
        }
        public async Task<RoomDTO> UpdateRoom(int id, RoomDTO room)
        {
            Room room1 = new Room
            {
                Id = room.ID,
                Name = room.Name,
                layout = room.Layout
            };
            _context.Entry(room1).State = EntityState.Modified;
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
        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var removedAmenity = await _context.RoomAmenities.FirstOrDefaultAsync(i => i.RoomID == roomId && i.AmenitiesId == amenityId);
            _context.RoomAmenities.Remove(removedAmenity);
            //_context.Entry(removedAmenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
