using System;
using System.Collections.Generic;
using System.Text;

namespace dwp.ms.demo.registration.domain.Exception
{
    public class RegistrationDomainException: System.Exception
    {
        public RegistrationDomainException()
        { }

        public RegistrationDomainException(string message)
            : base(message)
        { }

        public RegistrationDomainException(string message, System.Exception innerException)
            : base(message, innerException)
        { }
    }
}
