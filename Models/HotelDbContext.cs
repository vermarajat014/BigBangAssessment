using Microsoft.EntityFrameworkCore;

namespace HotelProj.Models
{
    
    //Here I am providing DbContext for hotel and rooms
    public class HotelDbContext:DbContext
    {

        public HotelDbContext(DbContextOptions<HotelDbContext>Options):base(Options) { }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Rooms> Rooms { get; set; }
        

        //Creating Connection Link Between Hotel And Rooms(using foreign key i.e. Hotel_Id)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rooms>()
                .HasOne(h => h.Hotel)
                .WithMany(r => r.Rooms)
                .HasForeignKey(p => p.Hotel_Id);
        }

        
    }
}
