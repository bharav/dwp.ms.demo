using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dwp.ms.demo.registration.domain.SeedWork;
using dwp.ms.demo.registration.domain.AggregatesModel;

namespace dwp.ms.demo.registration.domain.AggregatesModel.RegistrationAggregate
{
    public interface IRegistrationRepository : IRepository<Registration>
    {
        Registration Add(Registration registration);
        Task<Registration> GetAsync(string regNo);

    }
}
