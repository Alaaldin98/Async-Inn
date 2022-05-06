using HotelManagement.Data;
using HotelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Models.Servieces
{
    public class HotelRoomRepo : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomRepo(AsyncInnDbContext context)
        {
           _context = context;
        }
        public async Task<HotelRoom> Create(int id, HotelRoom hotelroom)
        {
            hotelroom.HotelId = id;
            _context.Entry(hotelroom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelroom;
        }

       

        public async Task<HotelRoom> GetHotelRoom(int HotelId, int RoomNum)
        {
            return await _context.HotelRoom.Include(x => x.room)
                                                   .ThenInclude(x => x.roomamenity)
                                                   .ThenInclude(x => x.amenity)
                                                   .Include(r => r.hotel)
                                                   .ThenInclude(x => x.hotel)
                                                   .FirstOrDefaultAsync(x => x.HotelId == HotelId && x.RoomNumber == RoomNum);

        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            return await _context.HotelRoom.Include(hr => hr.room)
                                           .ThenInclude(r => r.roomamenity)
                                           .ThenInclude(x => x.amenity)
                                           .Include(hr => hr.hotel)
                                           .ThenInclude(h => h.hotel)
                                           .ToListAsync(); // list of hotelroom

        }

        public async Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom hotelroom)
        {
            _context.Entry(hotelroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelroom;
        }
        public async Task Delete(int HotelId, int RoomNum)
        {
            HotelRoom hotelroom = await GetHotelRoom( HotelId, RoomNum);
            _context.Entry(hotelroom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Task<HotelRoom> GetHotelRoom(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<HotelRoom> UpdateHotelRoom(int id, int roomNumber, HotelRoom hotelroom)
        {
            throw new System.NotImplementedException();
        }
    }
}
