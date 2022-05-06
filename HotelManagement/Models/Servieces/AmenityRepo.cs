using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HotelManagement.Models.Servieces
{
    public class AmenityRepo : IAmenity
    {
        private readonly AsyncInnDbContext _context;
        public AmenityRepo(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenities.Include(x => x.amenity)
                                        .ThenInclude(x => x.room)
                                        .ToListAsync();
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            return await _context.Amenities.Include(x => x.amenity)
                                         .ThenInclude(x => x.room)
                                         .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
