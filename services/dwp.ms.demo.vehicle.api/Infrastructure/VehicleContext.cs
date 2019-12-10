using Microsoft.EntityFrameworkCore;
using dwp.ms.demo.vehicle.api.Infrastructure.EntityConfigurations;
using dwp.ms.demo.vehicle.api.Model;
using Microsoft.EntityFrameworkCore.Design;

namespace dwp.ms.demo.vehicle.api.Infrastructure
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
        }


    }

    public class VehicleContextDesignFactory : IDesignTimeDbContextFactory<VehicleContext>
    {
        public VehicleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VehicleContext>()
                .UseSqlServer("Server=.;Initial Catalog=VehicleManufacturer;Integrated Security=true");

            return new VehicleContext(optionsBuilder.Options);
        }
    }
}
