using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwp.ms.demo.registration.Queries
{
    public interface IRegistrationQueries
    {
        Task<Registration> GetRegistrationAsync(int regId);

    }
}
