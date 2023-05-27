using HotelProj.Models;

namespace HotelProj.Repository
{
    //created Interface for hotel
    public interface HIRepository
    {
        IEnumerable<Hotel> GetAllHotels();
        void addHotel(Hotel hotel);
        Hotel GetHotelById(int id);
        void DeleteHotel(int id);
        void UpdateHotel(Hotel hotel, int id);
       
        
    }
}
