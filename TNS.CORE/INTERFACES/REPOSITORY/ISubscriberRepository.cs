using TNS.CORE.MODELS;

namespace TNS.CORE.INTERFACES.REPOSITORY;

public interface ISubscriberRepository
{
    Task Add(Subscriber subscriber);
    //Task Remove(Guid subscriberId);
    //Task<List<Subscriber>> Get();
    //Task<Subscriber> GetById(Guid subscriberId);
    //Task Update(Subscriber subscriber);
}
