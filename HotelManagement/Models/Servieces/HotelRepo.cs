using HotelManagement.Data;
using HotelManagement.Models;
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
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
       



        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            // Hotel hotel = await _context.Hotels.FindAsync(id);
            //return hotel;
            /*   Hotel hotel = await _context.Hotels.FindAsync(id);
                var hotelroom = await _context.HotelRoom.Where(x => x.HotelId == id).Include(x => x.hotel)
                    .ToListAsync();
                hotel.hotel = hotelroom;
                return hotel; */
            return await _context.Hotels
                                    .Include(e => e.hotel)
                                    .ThenInclude(c => c.room)
                                    .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels
                                    .Include(e => e.hotel)
                                    .ThenInclude(c => c.room)
                                    .ToListAsync();
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
