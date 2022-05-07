using HotelManagement.Data;
using HotelManagement.Models.DTO;
using HotelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<HotelRoomDTO> Create(int id, HotelRoomDTO hotelRoom)
        {
            HotelRoom hotelRoom1 = new HotelRoom
            {
                HotelId = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                RoomID = hotelRoom.RoomID,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly
            };
            _context.Entry(hotelRoom1).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }



        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom roomDetails = await _context.HotelRoom
                .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                .FirstAsync();

            HotelRoom hotelRoom = await _context.HotelRoom.Include(r => r.room)
                                                           .ThenInclude(am => am.roomamenity)
                                                           .ThenInclude(a => a.amenity)
                                                           .Where(h => h.HotelId == roomDetails.HotelId && h.RoomID == roomDetails.RoomID)
                                                           .FirstAsync();
            return hotelRoom;
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId)
        {
            return await _context.HotelRoom
                                .Select(hrdt => new HotelRoomDTO()
                                {
                                    HotelID = hrdt.HotelId,
                                    RoomNumber = hrdt.RoomNumber,
                                    Rate = hrdt.Rate,
                                    PetFriendly = hrdt.PetFriendly,
                                    RoomID = hrdt.RoomID,
                                    Room = new RoomDTO()
                                    {
                                        ID = hrdt.room.Id,
                                        Name = hrdt.room.Name,
                                        Layout = hrdt.room.layout,
                                        Amenities = hrdt.room.roomamenity
                                        .Select(amenity => new AmenityDTO
                                        {
                                            ID = amenity.amenity.Id,
                                            Name = amenity.amenity.Name,
                                        }).ToList()
                                    }
                                }).ToListAsync();
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int HotelId, int RoomNum, HotelRoomDTO hotelRoom)
        {
            HotelRoom hotelRoom1 = new HotelRoom
            {
                HotelId = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                RoomID = hotelRoom.RoomID,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly
            };
            _context.Entry(hotelRoom1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
        public async Task Delete(int HotelId, int RoomNum)
        {
            var hotelRoom = await _context.HotelRoom
                 .Where(hr => hr.HotelId == HotelId && hr.RoomNumber == RoomNum)
                 .FirstAsync();

            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }


}

