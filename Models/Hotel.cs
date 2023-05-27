using System.ComponentModel.DataAnnotations;

namespace HotelProj.Models
{
    public class Hotel
    {

        //Here I Am Providing Hotel Details Entity

        [Key]

        public int Hotel_Id { get; set; }

        public string? Hotel_Name { get; set; }

        public string? Hotel_Address { get; set; }

        public string? Hotel_Contact { get; set; }
        
        public string? Hotel_Amenities { get;set; }

        public ICollection<Rooms>? Rooms { get; set; }

    }
}
