using TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;
using TNS.CORE.MODELS.SUBSCRIBER;

namespace TNS.PERSISTENCE.REPOSITORIES.SUBSCRIBER;

public class PersonRepository : IPersonRepository
{
    public Task Add(Person person)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Person>> GetAllPersons()
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Person person, Guid id)
    {
        throw new NotImplementedException();
    }
}
