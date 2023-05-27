using HotelProj.Models;

namespace HotelProj.Repository
{

    //Created Interface for Rooms
    public interface RIRepository
    {
        Rooms GetRoomById(int id);
        IEnumerable<Rooms> GetAllRooms();
        void AddRoom(Rooms rooms);
        void UpdateRoom(Rooms rooms, int id);
        void DeleteRoom(int id);
    }
}
