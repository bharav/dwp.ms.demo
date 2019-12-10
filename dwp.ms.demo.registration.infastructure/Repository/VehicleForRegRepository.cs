using dwp.ms.demo.registration.domain.AggregatesModel;
using dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate;
using dwp.ms.demo.registration.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace dwp.ms.demo.registration.infastructure.Repository
{
    public class VehicleForRegRepository : IVehicleYetToRegRepository
    {
        private readonly RegistrationContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public VehicleForRegRepository(RegistrationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public VehicleYetToRegister Add(VehicleYetToRegister vehicleYetToRegister)
        {
            return _context.VehicleYetToRegisters.Add(vehicleYetToRegister).Entity;
        }

        public VehicleYetToRegister GetAsync(string engineNo)
        {
            return  _context.VehicleYetToRegisters.Where(b => b._engineNo == engineNo)
                .FirstOrDefault(); ;
        }
    }
}
