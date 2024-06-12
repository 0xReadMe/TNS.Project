using TNS.CORE.MODELS.SUBSCRIBER;

namespace TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;

public interface IPersonRepository
{
    Task Add(Person person);
    Task Delete(Guid id);
    Task Update(Person person, Guid id);
    Task<Person> GetByGuid(Guid id);
    Task<List<Person>> GetAllPersons();
}
