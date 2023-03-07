using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Domain.ParkingLot> ParkingLot {get; set;}

        public DbSet<Domain.Vehicle> Vehicles {get; set;}
        public DbSet<Domain.Category> Categories {get; set;}
        public DbSet<Domain.Discount> Discounts { get; set; }
    }
}