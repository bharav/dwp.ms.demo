using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Events;

namespace dwp.ms.demo.vehicle.api.IntegrationEvents.Event
{
    public class VehicleAddedIntegrationEvent: IntegrationEvent
    {
        public string EngineNo { get; set; }

        public VehicleAddedIntegrationEvent(string engineNo)
            => EngineNo = engineNo;
    }
}
