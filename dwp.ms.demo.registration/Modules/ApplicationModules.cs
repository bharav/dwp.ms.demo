using Autofac;
using dwp.ms.demo.registration.domain.AggregatesModel;
using dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate;
using dwp.ms.demo.registration.infastructure.Repository;
using dwp.ms.demo.registration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwp.ms.demo.registration.Modules
{
    public class ApplicationModules:Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModules(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new RegistrationQueries(QueriesConnectionString))
                .As<IRegistrationQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RegistrationRepository>()
                .As<IRegistrationRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<VehicleForRegRepository>()
                 .As<IVehicleYetToRegRepository>()
                .InstancePerLifetimeScope();

        }
    }
}
