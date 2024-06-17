using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.EMPLOYEE;

namespace TNS.CORE.INTERFACES.SERVICES.EMPLOYEE;

public interface IEventService
{
    Task<Result> AddEvent(Event s);
    Task<Result> DeleteEvent(Guid id);
    Task<Result> UpdateEvent(Event subscriber, Guid id);
    Task<Result<Event>> GetByGuidEvent(Guid id);
    Task<Result<List<Event>>> GetAllEvent();
}
