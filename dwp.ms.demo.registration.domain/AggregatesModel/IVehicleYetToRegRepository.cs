using dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate;
using dwp.ms.demo.registration.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dwp.ms.demo.registration.domain.AggregatesModel
{
    public interface IVehicleYetToRegRepository:IRepository<VehicleYetToRegister>
    {
        VehicleYetToRegister Add(VehicleYetToRegister vehicleYetToRegister);
        VehicleYetToRegister GetAsync(string engineNo);
    }
}
