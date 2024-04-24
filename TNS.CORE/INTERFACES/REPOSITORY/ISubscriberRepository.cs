using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Database;

namespace TNS.CORE.INTERFACES.REPOSITORY
{
    internal interface ISubscriberRepository
    {
        Task Add(Subscriber subscriber);
        Task Remove(Guid subscriberId);
        Task<List<Subscriber>> Get();
        Task<Subscriber> GetById(Guid subscriberId);
        Task Update(Subscriber subscriber);
    }
}
