using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
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
              new Hotel { Id = 3, Name = "Mina Hotel",Address ="Aqaba",Phone =0868763450 }
            );
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = "Personal care" },
                new Amenity { Id = 2, Name = "Coffee Kit" },
                new Amenity { Id = 3, Name = "Tissue box" }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Single", Layout = "A room assigned to one person. May have one or more beds." },
                new Room { Id = 2, Name = "Double", Layout = "A room assigned to two people. May have one or more beds." },
                new Room { Id = 3, Name = "Triple", Layout = "A room assigned to three people. May have two or more beds." }
                );
                

        }
    }
}
