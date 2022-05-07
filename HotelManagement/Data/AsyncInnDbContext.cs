using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using static HotelManagement.Models.Room;

namespace HotelManagement.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }

        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "Life Hotel",Address ="Amman",Phone =0782625620 },
              new Hotel { Id = 2, Name = "7Star Hotel",Address ="Irbid",Phone =0797645630 },
              new Hotel { Id = 3, Name = "Mina Hotel",Address ="Aqaba",Phone =0868763450 },
              new Hotel {Id = 4, Name = "Jarash Hotel", Address = "Jarash", Phone = 75345626}
            );
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = "Personal care" },
                new Amenity { Id = 2, Name = "Coffee Kit" },
                new Amenity { Id = 3, Name = "Tissue box" }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Single", layout = 0 },
                new Room { Id = 2, Name = "Double", layout = (Layout)1 },
                new Room { Id = 3, Name = "Triple", layout = (Layout)1 }
                );
            // add a FK to HotelRoom, as CK
            modelBuilder.Entity<HotelRoom>().HasKey(
               hr => new { hr.HotelId, hr.RoomNumber }
           );

            // add a FK to RoomAmenities, as CK
            modelBuilder.Entity<RoomAmenities>().HasKey(
                ra => new { ra.RoomID, ra.AmenitiesId }
            );

        }
    }
}
