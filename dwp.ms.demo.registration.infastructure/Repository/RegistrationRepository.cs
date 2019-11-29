using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate;
using dwp.ms.demo.registration.domain.SeedWork;
using dwp.ms.demo.registration.infastructure;

namespace dwp.ms.demo.registration.infastructure.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly RegistrationContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public RegistrationRepository(RegistrationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Registration Add(Registration registration){
            return _context.Registrations.Add(registration).Entity;
        }

        public async Task<Registration> GetAsync(string regNo) {
            return await _context.Registrations.FindAsync(regNo);
        }
    }
}
