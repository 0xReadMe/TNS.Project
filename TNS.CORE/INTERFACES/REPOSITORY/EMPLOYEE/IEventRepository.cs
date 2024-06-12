using TNS.CORE.MODELS.EMPLOYEE;

namespace TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;

public interface IEventRepository
{
    Task Add(Event _event);
    Task Delete(Guid id);
    Task Update(Event _event, Guid id);
    Task<Event> GetByGuid(Guid id);
    Task<List<Event>> GetAllEvents();
}
