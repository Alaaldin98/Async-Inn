using HotelManagement.Data;
using HotelManagement.Models.DTO;
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
        public async Task<AmenityDTO> Create(AmenityDTO amenity)
        {
            Amenity amenities = new Amenity
            {
                Id = amenity.ID,
                Name = amenity.Name,
            };
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }



        public async Task<List<AmenityDTO>> GetAmenities()
        {
            return await _context.Amenities

              .Select(amenity => new AmenityDTO // select new AmenityDTO object
             {
                  ID = amenity.Id,
                  Name = amenity.Name,
              }).ToListAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {
            return await _context.Amenities

               .Select(amenity => new AmenityDTO // select new AmenityDTO object
               {
                   ID = id,
                   Name = amenity.Name,
               }).FirstOrDefaultAsync(a => a.ID == id); // one amenity

        }

        public async Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenitydto)
        {
            Amenity amenities = new Amenity
            {
                Id = amenitydto.ID,
                Name = amenitydto.Name,
            };
            _context.Entry(amenities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenitydto;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}