using System;
using System.Collections.Generic;
using System.Text;

namespace dwp.ms.demo.registration.domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

