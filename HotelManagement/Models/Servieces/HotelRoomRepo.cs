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
        public async Task<HotelRoom> Create(HotelRoom hotelroom)
        {
            _context.Entry(hotelroom).State =EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelroom;
        }

       

        public async Task<HotelRoom> GetHotelRoom(int id)
        {
            var hotelroom = await _context.HotelRoom.FindAsync(id);
            return hotelroom;
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            var hotelrooms = await _context.HotelRoom.ToListAsync();
            return hotelrooms;
        }

        public async Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom hotelroom)
        {
            _context.Entry(hotelroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelroom;
        }
        public async Task Delete(int id)
        {
            HotelRoom hotelroom = await GetHotelRoom(id);
            _context.Entry(hotelroom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
