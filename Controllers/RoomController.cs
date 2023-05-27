using HotelProj.Models;
using HotelProj.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProj.Controllers
{
    [Authorize]                     //Provide Authentication to both user and admin
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RIRepository _context;

        public RoomController(RIRepository context)
        {
            _context = context;
        }


        //Calling Function to Show Rooms details in controller
        [HttpGet]
        public ActionResult<ICollection<Rooms>> GetAllHotels()
        {
            try
            {
                var hotels = _context.GetAllRooms();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Controller to Add Rooms
        [HttpPost]
        public ActionResult<ICollection<Rooms>> CreateHotel(Rooms rooms)
        {
            try
            {
                _context.AddRoom(rooms);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Controller To delete Rooms by Id
        [HttpDelete("{id}")]
        public ActionResult<ICollection<Rooms>> DeleteHotel(int id)
        {
            try
            {
                _context.DeleteRoom(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Controller To Get Rooms details By Id
        [HttpGet("{id}")]
        public ActionResult<ICollection<Rooms>> GetHotelById(int id)
        {
            try
            {
                var rooms = _context.GetRoomById(id);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Controller to Update the details of Rooms
        [HttpPut("{id}")]
        public ActionResult<ICollection<Rooms>> UpdateHotel(int id, Rooms rooms)
        {
            try
            {
                _context.UpdateRoom(rooms, id);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
