using MediatR;
using dwp.ms.demo.registration.infastructure;
using dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate;
using dwp.ms.demo.registration.domain.SeedWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using dwp.ms.demo.registration.domain.AggregatesModel;

namespace dwp.ms.demo.registration.Application.Commands
{
    public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, bool>
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IVehicleYetToRegRepository _vehicleYetToRegRepository;
        public CreateRegistrationCommandHandler(IMediator mediator,
           IRegistrationRepository registrationRepository, IVehicleYetToRegRepository vehicleYetToRegRepository)
        {
            _registrationRepository = registrationRepository ?? throw new ArgumentNullException(nameof(registrationRepository));
            _vehicleYetToRegRepository = vehicleYetToRegRepository ?? throw new ArgumentNullException(nameof(vehicleYetToRegRepository));
        }

        public async Task<bool> Handle(CreateRegistrationCommand message, CancellationToken cancellationToken)
        {
            var isValidForRegistration = _vehicleYetToRegRepository.GetAsync(message.EngineNo);
            if (isValidForRegistration == null)
            {
                return false;
            }
            var registration = new Registration(message.RegNo, message.Name, message.Address, message.Phone, message.ChesisNo, message.EngineNo);
            _registrationRepository.Add(registration);
            return await _registrationRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}
