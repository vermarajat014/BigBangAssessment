using HotelProj.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HotelProj.Repository
{
    //Created repository For Room Controller
    public class RRepository : RIRepository
    {
        private readonly HotelDbContext _context;

        public RRepository(HotelDbContext context)
        {
            _context = context;
        }

        //Calling Interface To Show Rooms Details
        public IEnumerable<Rooms> GetAllRooms()
        {
            return _context.Rooms.Include(b => b.Hotel).ToList();
        }
        

        //Calling Interface to Add Rooms
        public void AddRoom(Rooms rooms)
        {
            _context.Rooms.Add(rooms);
            _context.SaveChanges();
        }

        //Calling Interface To delete a Rooms
        public void DeleteRoom(int id)
        {
            var R = _context.Rooms.Find(id);
            _context.Rooms.Remove(R);
            _context.SaveChanges();
        }

        //Calling Imterface to Get Rooms By Id
        public Rooms GetRoomById(int id)
        {
            var Rdet = _context.Rooms.Find(id);
            return Rdet;
        }

        //Calling Interface to Update Rooms Details
        public void UpdateRoom(Rooms R, int id)
        {
            var Rup = _context.Rooms.Find(id);
            Rup.Availability_status = R.Availability_status;
            _context.Rooms.Update(Rup);
            _context.SaveChanges();
        }

       
    }
}
