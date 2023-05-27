using HotelProj.Models;
using HotelProj.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProj.Controllers
{
    [Authorize (Roles = "Admin")] //It is use to provide authentication to only admin to control all the controllers.
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HIRepository _context;

        public HotelController(HIRepository context)
        {
            _context = context;
        }

        //Calling Function to Show hotel details in controller
        [HttpGet]
        public IActionResult GetAllHotels()
        {
            try
            {
                var hotels = _context.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Controller to Add hotels
        [HttpPost]
        public IActionResult CreateHotel(Hotel h)
        {
            try
            {
                _context.addHotel(h);
                return Ok(h);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Controller To delete hotel by Id
        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            try
            {
                _context.DeleteHotel(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        //Controller To Get Hotel details By Id
        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var h = _context.GetHotelById(id);
                if (h == null)
                {
                    return NotFound();
                }

                return Ok(h);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Controller to Update the details of Hotel
        [HttpPut("{id}")]
        public ActionResult<ICollection<Hotel>> UpdateHotel(int id, Hotel hotel)
        {
            try
            {
                _context.UpdateHotel(hotel, id);
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
