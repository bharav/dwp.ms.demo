using FluentValidation;
using dwp.ms.demo.registration.Application.Commands;
using Microsoft.Extensions.Logging;

namespace dwp.ms.demo.registration.Validation
{
    public class CreateRegistrationValidatior : AbstractValidator<CreateRegistrationCommand>
    {
        public CreateRegistrationValidatior(ILogger<CreateRegistrationValidatior> logger) {

            RuleFor(command => command.RegNo).NotEmpty();
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.Address).NotEmpty();
            RuleFor(command => command.Phone).NotEmpty();
            RuleFor(command => command.EngineNo).NotEmpty();
            RuleFor(command => command.ChesisNo).NotEmpty();

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);


        }
    }
}
