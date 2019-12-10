using dwp.ms.demo.vehicle.api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dwp.ms.demo.vehicle.api.Infrastructure.EntityConfigurations
{
    class VehicleEntityTypeConfiguration
         : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");

            builder.HasKey(ci => ci.EngineNo);

            builder.Property(cb => cb.ChesisNo)
                .IsRequired();
            builder.Property(cb => cb.BatchNo).IsRequired();

            builder.Property(cb => cb.Manufacturer).IsRequired();
            
            builder.Property(cb => cb.ModelName).IsRequired();

            builder.Property(cb => cb.Variant).IsRequired();

            builder.Property(cb => cb.YearOfManufacture).IsRequired();

            builder.Property(cb => cb.MonthOfManufacture).IsRequired();
        }
    }
}
