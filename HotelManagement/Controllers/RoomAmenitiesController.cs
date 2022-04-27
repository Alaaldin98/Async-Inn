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
    public class RoomAmenitiesController : ControllerBase
    {
        private readonly IRoomAmenities _roomamenities;

        public RoomAmenitiesController(IRoomAmenities roomamenities)
        {
            _roomamenities = roomamenities;
        }

        // GET: api/RoomAmenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAmenities>>> GetRoomAmenities()
        {
            var roomAmenities = await _roomamenities.GetRoomAmenities();
            return Ok(roomAmenities);
        }

        // GET: api/RoomAmenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomAmenities>> GetRoomAmenity(int id)
        {
            var Course = await _roomamenities.GetRoomAmenity(id);
            return Ok(Course);
        }

        // PUT: api/RoomAmenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomAmenities(int id, RoomAmenities roomAmenities)
        {
            if (id != roomAmenities.RoomID && id != roomAmenities.AmenitiesId )
            {
                return NoContent();
            }
            var UpdateroomAmenities = await _roomamenities.UpdateRoomAmenities(id, roomAmenities);
            return Ok(UpdateroomAmenities);
        }

        // POST: api/RoomAmenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomAmenities>> PostRoomAmenities(RoomAmenities roomAmenities)
        {
            await _roomamenities.Create(roomAmenities);
            return CreatedAtAction("GetCourse", new { id = roomAmenities.RoomID }, roomAmenities);
        }

        // DELETE: api/RoomAmenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomAmenities(int id)
        {
            await _roomamenities.Delete(id);
            return NoContent();
        }

       
    }
}
