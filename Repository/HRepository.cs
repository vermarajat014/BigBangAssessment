using HotelProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HotelProj.Repository
{
    public class HRepository : HIRepository
    {

        private readonly HotelDbContext _context;

        public HRepository(HotelDbContext context)
        {
            _context = context;
        }

        //Calling Interface To Show Hotel Details
        public IEnumerable<Hotel> GetAllHotels()
        {
            return _context.Hotel.Include(a=>a.Rooms).ToList();     
        }


        //Calling Interface to Add Hotel
        public void addHotel(Hotel h)
        {
            _context.Hotel.Add(h);
            _context.SaveChanges();
        }

        //calling Interface To delete a hotel
        public void DeleteHotel(int id)
        {
            var h = _context.Set<Hotel>().Find(id);
            _ = _context.Set<Hotel>().Remove(h);
            _context.SaveChanges();  
        }

        //Calling Imterface to Get Hotel By Id
        public Hotel GetHotelById(int id)
        {
             var det=_context.Hotel.Find(id);
            return det;
        }

        //Calling Interface to Update Hotel Details
        public void UpdateHotel(Hotel h, int id)
        {
            var Hup = _context.Hotel.Find(id);
           
            Hup.Hotel_Name = h.Hotel_Name;
            Hup.Hotel_Address = h.Hotel_Address;
            Hup.Hotel_Contact=h.Hotel_Contact;
            Hup.Hotel_Amenities=h.Hotel_Amenities;

            _context.Hotel.Update(Hup);
            _context.SaveChanges();
        }


    }
}
