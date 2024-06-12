using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.SUBSCRIBER;

namespace TNS.CORE.INTERFACES.SERVICES.SUBSCRIBER;

public interface ISubscriberService
{
    Task<Result> AddSubscriber(Subscriber s);
    Task<Result> DeleteSubscriber(Guid id);
    Task<Result> UpdateSubscriber(Subscriber subscriber, Guid id);
    Task<Result<Subscriber>> GetByGuidSubscriber(Guid id);
    Task<Result<List<Subscriber>>> GetAllSubscribers();
}
