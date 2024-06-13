using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.SUBSCRIBER;

namespace TNS.CORE.INTERFACES.SERVICES.SUBSCRIBER;

public interface IPersonService
{
    Task<Result> AddPerson(Person s);
    Task<Result> DeletePerson(Guid id);
    Task<Result> UpdatePerson(Person subscriber, Guid id);
    Task<Result<Person>> GetByGuidPerson(Guid id);
    Task<Result<List<Person>>> GetAllPersons();
}
