using System;
using System.Collections.Generic;
using System.Text;

namespace dwp.ms.demo.registration.domain.Exception
{
   public class VehicleYetToRegDomainException : System.Exception
    {

        public VehicleYetToRegDomainException()
        { }

        public VehicleYetToRegDomainException(string message)
            : base(message)
        { }

        public VehicleYetToRegDomainException(string message, System.Exception innerException)
            : base(message, innerException)
        { }
    }
}
