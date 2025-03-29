
using Microsoft.EntityFrameworkCore;

namespace fuel_manager_api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Consumption> Consumptions { get; set; }

    }
}
