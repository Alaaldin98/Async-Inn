using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Models.Interfaces;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelroom;

        public HotelRoomsController(IHotelRoom hotelroom)
        {
            _hotelroom = hotelroom;
        }

        // GET: api/HotelRoom/{hotelId}/Rooms
        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms()
        {
            return Ok(await _hotelroom.GetHotelRooms());

        }

        // GET: api/HotelRoom/{hotelId}/Rooms/{roomNumber}
        [HttpGet("{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int HotelID, int RoomNumber)
        {
            var hotelRoom = await _hotelroom.GetHotelRoom(HotelID, RoomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int id, int RoomNumber, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelId && RoomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }
            var modifiedHotelRoom = await _hotelroom.UpdateHotelRoom(id, RoomNumber, hotelRoom);
            return Ok(modifiedHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int id ,HotelRoom hotelRoom)
        {
            HotelRoom newHotelRoom = await _hotelroom.Create(id, hotelRoom);
            return Ok(newHotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int HotelID, int RoomNumber)
        {
            await _hotelroom.Delete(HotelID, RoomNumber);
            return NoContent();
        }


    }
}
