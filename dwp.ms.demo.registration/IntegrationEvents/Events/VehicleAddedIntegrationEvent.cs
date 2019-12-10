using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Events;

namespace dwp.ms.demo.registration.IntegrationEvents.Events
{
    public class VehicleAddedIntegrationEvent : IntegrationEvent
    {
        public string EngineNo { get; set; }

        public VehicleAddedIntegrationEvent(string engineNo)
        {
            EngineNo = engineNo;
        }
    }
}
