using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate;

namespace dwp.ms.demo.registration.infastructure.EntityConfiguration
{
    class VehicleYetToRegisterEntityConfiguration : IEntityTypeConfiguration<VehicleYetToRegister>
    {
        public void Configure(EntityTypeBuilder<VehicleYetToRegister> vehicleForRegistrationConfiguration)
        {
            vehicleForRegistrationConfiguration.ToTable("VehicleYetToRegister", RegistrationContext.DEFAULT_SCHEMA);
            vehicleForRegistrationConfiguration.HasKey(o => o.Id);
            vehicleForRegistrationConfiguration.Property<string>("_engineNo").HasColumnName("EngineNo").IsRequired();
        }
    }
}
