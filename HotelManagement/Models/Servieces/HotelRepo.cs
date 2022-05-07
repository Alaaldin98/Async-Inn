using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Models.DTO;
using HotelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers.Servieces
{
    public class HotelRepo : IHotel
    {
        private readonly AsyncInnDbContext _context;
        public HotelRepo(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<HotelDTO> Create(HotelDTO hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }
        public async Task<HotelDTO> GetHotel(int id)
        {
            // Hotel hotel = await _context.Hotels.FindAsync(id);
            //return hotel;
            /*   Hotel hotel = await _context.Hotels.FindAsync(id);
                var hotelroom = await _context.HotelRoom.Where(x => x.HotelId == id).Include(x => x.hotel)
                    .ToListAsync();
                hotel.hotel = hotelroom;
                return hotel; */
            /*
             .Include(e => e.hotel)
                                    .ThenInclude(c => c.room)
                                    .FirstOrDefaultAsync(a => a.Id == id);
        
             */

            return await _context.Hotels

             .Select(hotel => new HotelDTO
             {
                 ID = id,
                 Name = hotel.Name,
                 StreetAddress = hotel.Address,
                
                 Phone = hotel.Phone,
                 Rooms = hotel.hotelrooms
                 .Select(r => new HotelRoomDTO
                 {
                     HotelID = r.hotel.Id,
                     RoomNumber = r.RoomNumber,
                     Rate = r.Rate,
                     PetFriendly = r.PetFriendly,
                     RoomID = r.RoomID,
                     
                 }).ToList()
             }).FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<List<HotelDTO>> GetHotels()
        {
            return await _context.Hotels.Select(
                 hotel => new HotelDTO
                 {
                     ID = hotel.Id,
                     Name = hotel.Name,
                     StreetAddress = hotel.Address,
                     City = hotel.City,
                     State = hotel.State,
                     Phone = hotel.Phone,
                     Rooms = hotel.hotelrooms.Select(hotelR => new HotelRoomDTO
                     {
                         HotelID = hotelR.HotelId,
                         RoomNumber = hotelR.RoomNumber,
                         Rate = hotelR.Rate,
                         PetFriendly = hotelR.PetFriendly,
                         RoomID = hotelR.RoomID,
                         Room = new RoomDTO
                         {
                             ID = hotelR.room.Id,
                             Name = hotelR.room.Name,
                             Layout = hotelR.room.layout,
                             Amenities = hotelR.room.roomamenity
                             .Select(A => new AmenityDTO
                             {
                                 ID = A.amenity.Id,
                                 Name = A.amenity.Name
                             }).ToList()
                         }
                     }).ToList()
                 }).ToListAsync();
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            HotelDTO hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
