using System.ComponentModel.DataAnnotations;

namespace HotelProj.Models
{
    public class Rooms
    {

        //Here I am Providing Hotels Room Details database entity

        [Key]
        public int Room_Id { get; set; }

        public string? Room_type { get; set; }

        public bool Availability_status { get; set; }

        public int Room_price { get; set; }

        public string? Room_Number { get; set; }

        public int Hotel_Id { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
