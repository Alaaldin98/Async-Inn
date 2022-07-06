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
using HotelManagement.Models.DTO;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "read")]

        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await _hotelroom.GetHotelRooms(hotelId);
            return Ok(hotelRooms);

        }

        // GET: api/HotelRoom/{hotelId}/Rooms/{roomNumber}
        [Authorize(Policy = "read")]

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
        [Authorize(Policy = "update")]

        [HttpPut("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int id, int RoomNumber, HotelRoomDTO hotelRoom)
        {
            if (id != hotelRoom.HotelID && RoomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }
            var modifiedHotelRoom = await _hotelroom.UpdateHotelRoom(id, RoomNumber, hotelRoom);
            return Ok(modifiedHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int id ,HotelRoomDTO hotelRoom)
        {
            var newHotelRoom = await _hotelroom.Create(id, hotelRoom);
            return Ok(newHotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [Authorize(Policy = "delete")]

        [HttpDelete("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int HotelID, int RoomNumber)
        {
            await _hotelroom.Delete(HotelID, RoomNumber);
            return NoContent();
        }


    }
}
