using HotelProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterCountController : ControllerBase
    {

        private readonly HotelDbContext _context;

        public  FilterCountController(HotelDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Hotel>> GetHotels(
                string? Hotel_Address, string? Hotel_Amenities)
        {
            try {
                

                // Constructed the base query to retrieve hotels
                IQueryable<Hotel> query = _context.Hotel;

                // Apply filters based on the provided criteria
                if (!string.IsNullOrEmpty(Hotel_Address))
                {
                    query = query.Where(h => h.Hotel_Address == Hotel_Address);
                }

                if (!string.IsNullOrEmpty(Hotel_Amenities))
                {
                    query = query.Where(h => h.Hotel_Amenities.Contains(Hotel_Amenities));
                }

                // Execute the query and retrieve the filtered hotels
                List<Hotel> filteredHotels = query.ToList();

                // Return the filtered hotels as a response
                return Ok(filteredHotels);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        //Retrieving the available Rooms In particular hotel
        [HttpGet("{Hotel_Id}/Availability_status/count")]
        public ActionResult<int> GetAvailableRoomsCount(int hotelId)
        {
            try
            {
                // Retrieve the hotel by ID
                Hotel ?hotels = _context.Hotel.FirstOrDefault(h => h.Hotel_Id == hotelId);

                if (hotels == null)
                {
                    return NotFound(); // Hotel not found
                }

                // Count the available rooms in the hotel
                int availableRoomsCount = _context.Rooms.Count(r => r.Hotel_Id == hotelId && r.Availability_status == false);

                return Ok(availableRoomsCount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
