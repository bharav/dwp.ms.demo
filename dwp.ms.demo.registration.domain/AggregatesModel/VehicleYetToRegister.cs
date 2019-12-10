using System;
using System.Collections.Generic;
using System.Text;
using dwp.ms.demo.registration.domain.SeedWork;

namespace dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate
{
    public class VehicleYetToRegister : Entity, IAggregateRoot
    {
        public string _engineNo;
        public VehicleYetToRegister(string engineNo)
        {
            _engineNo = engineNo;
        }
    }
}
