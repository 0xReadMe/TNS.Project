using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;
using TNS.CORE.INTERFACES.SERVICES.SUBSCRIBER;
using TNS.CORE.MODELS.SUBSCRIBER;

namespace TNS.APPLICATION.SERVICES.SUBSCRIBER;

public class PersonService(IPersonRepository personsRepository) : IPersonService
{
    public readonly IPersonRepository _personsRepository = personsRepository;

    public async Task<Result> AddPerson(Person s)
    {
        try
        {
            await _personsRepository.Add(s);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при добавлении: {ex}");
        }
    }

    public async Task<Result> DeletePerson(Guid id)
    {
        try
        {
            await _personsRepository.Delete(id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при удалении: {ex}");
        }
    }

    public async Task<Result<List<Person>>> GetAllPersons()
    {
        try
        {
            List<Person> sub = await _personsRepository.GetAllPersons();
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Person>>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<Person>> GetByGuidPerson(Guid id)
    {
        try
        {
            Person sub = await _personsRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<Person>($"Ошибка при получении абонента: {ex}");
        }
    }

    public async Task<Result> UpdatePerson(Person subscriber, Guid id)
    {
        try
        {
            await _personsRepository.Update(subscriber, id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при обновлении данных: {ex}");
        }
    }
}
