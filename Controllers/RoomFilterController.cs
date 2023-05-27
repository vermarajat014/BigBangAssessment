using HotelProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomFilterController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public RoomFilterController(HotelDbContext context)
        {
            _context = context;
        }

        //Filtering Rooms according to Price
        [HttpGet]
        public ActionResult<IEnumerable<Rooms>> Getrooms(
                decimal? minPrice, decimal? maxPrice)
        {
            try
            {

                // Construct the base query to retrieve rooms
                IQueryable<Rooms> query = _context.Rooms;

                if (minPrice.HasValue)
                {
                    query = query.Where(h => h.Room_price >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(h => h.Room_price <= maxPrice.Value);
                }

                // Execute the query and retrieve the filtered Rooms
                List<Rooms> filteredRooms = query.ToList();

                // Return the filtered hotels as a response
                return Ok(filteredRooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
