using HotelManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static HotelManagement.Models.Room;

namespace HotelManagement.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "Life Hotel", Address = "Amman", Phone = "0782625620", StreetAddress = "Real street", City = "Amman", State = "dlkg", Country = "Jordan" },
              new Hotel { Id = 2, Name = "7Star Hotel", Address = "Irbid", Phone = "0797645630", StreetAddress = "north street ", City = "irbid", State = "Illinois", Country = "Jordan" },
              new Hotel { Id = 3, Name = "Mina Hotel", Address = "Aqaba", Phone = "0868763450", StreetAddress = "south street", City = "aqaba", State = "dczds", Country = "Jordan" },
              new Hotel { Id = 4, Name = "Jarash Hotel", Address = "Jarash", Phone = "075345626", StreetAddress = "yarmouk treet", City = "sjarash", State = "Illidfs", Country = "Jordan" }
            );
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = "Personal care" },
                new Amenity { Id = 2, Name = "Coffee Kit" },
                new Amenity { Id = 3, Name = "Tissue box" }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Single", layout = "One single bed " },
                new Room { Id = 2, Name = "Double", layout = "Two single bed " },
                new Room { Id = 3, Name = "Triple", layout = "Three single bed " }
                );
            // add a FK to HotelRoom, as CK
            modelBuilder.Entity<HotelRoom>().HasKey(
               hr => new { hr.HotelId, hr.RoomNumber }
           );

            // add a FK to RoomAmenities, as CK
            modelBuilder.Entity<RoomAmenities>().HasKey(
                ra => new { ra.RoomID, ra.AmenitiesId }
            );
            SeedRoles(modelBuilder, "DistrictManager", "create", "update", "delete", "read");
            SeedRoles(modelBuilder, "PropertyManager", "create", "update", "read");
            SeedRoles(modelBuilder, "Agent", "update", "read");
            SeedRoles(modelBuilder, "AnonymousUsers", "read");
        }
       private int id = 1;
        private void SeedRoles(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
            var RoleClaims = permissions.Select(permissions =>
            new IdentityRoleClaim<string>
            {
                Id = id++,
                RoleId = role.Id,
                ClaimType = "persmissions",
                ClaimValue = permissions
            }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(RoleClaims);
        }
    }
}
