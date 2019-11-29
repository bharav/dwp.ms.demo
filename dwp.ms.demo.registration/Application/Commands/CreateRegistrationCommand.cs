using MediatR;


namespace dwp.ms.demo.registration.Application.Commands
{

    public class CreateRegistrationCommand : IRequest<bool>
    {
        public string RegNo { get;  set; }

        public string Name { get;  set; }

        public string Address { get;  set; }

        public string Phone { get;  set; }

        public string ChesisNo { get;  set; }

        public string EngineNo { get;  set; }


        //public CreateRegistrationCommand(string regNo, string name, string address, string phone, string chesisNo, string engineNo)
        //{
        //    RegNo = regNo;
        //    Name = name;
        //    Address = address;
        //    Phone = phone;
        //    ChesisNo = chesisNo;
        //    EngineNo = engineNo;
        //}


    }
}
