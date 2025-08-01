using System.Data.Entity;

namespace RosondFleetManager.Models
{
    public class RosondFleetManagerContext : DbContext
    {
        public RosondFleetManagerContext() : base("name=RosondFleetManagerContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }
    }
}