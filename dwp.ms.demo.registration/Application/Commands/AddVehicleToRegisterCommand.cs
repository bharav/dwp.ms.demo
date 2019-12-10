using MediatR;

namespace dwp.ms.demo.registration.Application.Commands
{
    public class AddVehicleToRegisterCommand : IRequest<bool>
    {
        public string EngineNo { get; set; }
        public AddVehicleToRegisterCommand(string engineNo)
        {
            EngineNo = engineNo;
        }
    }
}
