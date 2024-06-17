using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.SERVICES.EMPLOYEE;
using TNS.CORE.MODELS.EMPLOYEE;

namespace TNS.APPLICATION.SERVICES.EMPLOYEE;

public class EventService : IEventService
{
    public Task<Result> AddEvent(Event s)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteEvent(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Event>>> GetAllEvent()
    {
        throw new NotImplementedException();
    }

    public Task<Result<Event>> GetByGuidEvent(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateEvent(Event subscriber, Guid id)
    {
        throw new NotImplementedException();
    }
}
