using TNS.CORE.MODELS.SUBSCRIBER;

namespace TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;

public interface ISubscriberRepository
{
    Task Add(Subscriber s);
    Task Delete(Guid id);
    Task Update(Subscriber subscriber, Guid id);
    Task<Subscriber> GetByGuid(Guid id);
    Task<List<Subscriber>> GetAllSubscribers();
}
