using MediatR;
using dwp.ms.demo.registration.infastructure;
using dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate;
using dwp.ms.demo.registration.domain.SeedWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using dwp.ms.demo.registration.Application.Commands;
using dwp.ms.demo.registration.domain.AggregatesModel;

namespace dwp.ms.demo.registration.Application.DomainEventHandler.CreateRegistration
{
    public class AddVehicleToRegisterDomainEventHandler : IRequestHandler<AddVehicleToRegisterCommand, bool>
    {
        private readonly IVehicleYetToRegRepository _vehicleYetToRegRepository;
        public AddVehicleToRegisterDomainEventHandler(IMediator mediator,
           IVehicleYetToRegRepository vehicleYetToRegRepository)
        {
            _vehicleYetToRegRepository = vehicleYetToRegRepository ?? throw new ArgumentNullException(nameof(vehicleYetToRegRepository));
        }

        public async Task<bool> Handle(AddVehicleToRegisterCommand message, CancellationToken cancellationToken)
        {
            var vehicleYetToRegister = new VehicleYetToRegister(message.EngineNo);
            _vehicleYetToRegRepository.Add(vehicleYetToRegister);
            return await _vehicleYetToRegRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
       
    }
}
