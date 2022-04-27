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

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms()
        {
        var hotelRooms = await _hotelroom.GetHotelRooms();
            return Ok(hotelRooms);
        }

        // GET: api/HotelRooms/5
        [HttpGet("{hotelID}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelID)
        {
            var hotelRooms = await _hotelroom.GetHotelRoom(hotelID);
            return Ok(hotelRooms);
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelId)
            {
                return BadRequest();
            }
            var updatedhotelRooms = await _hotelroom.UpdateHotelRoom(id,hotelRoom);
            return Ok(updatedhotelRooms);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            var createdhotelRooms = await _hotelroom.Create( hotelRoom);
            return Ok(createdhotelRooms);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelRoom(int id)
        {
            await _hotelroom.Delete(id);

            return NoContent();
        }

        
    }
}
