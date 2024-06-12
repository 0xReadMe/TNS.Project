using TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;
using TNS.CORE.MODELS.EMPLOYEE;

namespace TNS.PERSISTENCE.REPOSITORIES.EMPLOYEE;

public class EventRepository : IEventRepository
{
    public Task Add(Event _event)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Event>> GetAllEvents()
    {
        throw new NotImplementedException();
    }

    public Task<Event> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Event _event, Guid id)
    {
        throw new NotImplementedException();
    }
}
