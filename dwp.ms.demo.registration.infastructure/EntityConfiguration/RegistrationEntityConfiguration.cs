using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate;
using System;

namespace dwp.ms.demo.registration.infastructure.EntityConfiguration
{
    class RegistrationEntityConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> registrationConfiguration)
        {
            registrationConfiguration.ToTable("Registration", RegistrationContext.DEFAULT_SCHEMA);
            registrationConfiguration.HasKey(o => o.Id);
            registrationConfiguration.Property<string>("_regNo").HasColumnName("RegNo").IsRequired();
            registrationConfiguration.Property<string>("_name").HasColumnName("Name").IsRequired();
            registrationConfiguration.Property<string>("_address").HasColumnName("Address").IsRequired();
            registrationConfiguration.Property<string>("_phone").HasColumnName("Phone").IsRequired();
            registrationConfiguration.Property<string>("_chesisNo").HasColumnName("ChesisNo").IsRequired();
            registrationConfiguration.Property<string>("_engineNo").HasColumnName("EngineNo").IsRequired();

        }
    }
}

