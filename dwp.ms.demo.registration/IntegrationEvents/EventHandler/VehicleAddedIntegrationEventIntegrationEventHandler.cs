using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dwp.ms.demo.registration.Application.Commands;
using dwp.ms.demo.registration.IntegrationEvents.Events;
using EventBus.Abstractions;
using EventBus.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace dwp.ms.demo.registration.IntegrationEvents.EventHandler
{
    public class VehicleAddedIntegrationEventIntegrationEventHandler : IIntegrationEventHandler<VehicleAddedIntegrationEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<VehicleAddedIntegrationEventIntegrationEventHandler> _logger;

        public VehicleAddedIntegrationEventIntegrationEventHandler(
            IMediator mediator,
            ILogger<VehicleAddedIntegrationEventIntegrationEventHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task Handle(VehicleAddedIntegrationEvent @event)
        {

            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, "Registration", @event);

            var command = new AddVehicleToRegisterCommand(@event.EngineNo);

            await _mediator.Send(command);
        }
    }

}
