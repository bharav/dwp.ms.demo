using System;


namespace dwp.ms.demo.vehicle.api.Infrastructure.Exceptions
{
    public class VehicleDomainException : Exception
    {
        public VehicleDomainException()
        { }

        public VehicleDomainException(string message)
            : base(message)
        { }

        public VehicleDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
