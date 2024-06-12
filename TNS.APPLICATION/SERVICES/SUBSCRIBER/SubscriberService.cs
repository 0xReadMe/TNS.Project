using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;
using TNS.CORE.INTERFACES.SERVICES.SUBSCRIBER;
using TNS.CORE.MODELS.SUBSCRIBER;

namespace TNS.APPLICATION.SERVICES.SUBSCRIBER;

public class SubscriberService(ISubscriberRepository lessonsRepository) : ISubscriberService
{
    public readonly ISubscriberRepository _lessonsRepository = lessonsRepository;

    public async Task<Result> AddSubscriber(Subscriber s)
    {
        try 
        {
            await _lessonsRepository.Add(s);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при добавлении: {ex}");
        }
    }

    public async Task<Result> DeleteSubscriber(Guid id)
    {
        try 
        {
            await _lessonsRepository.Delete(id);
            return Result.Success();
        }
        catch (Exception ex) 
        {
            return Result.Failure($"Ошибка при удалении: {ex}");
        }
    }

    public async Task<Result> UpdateSubscriber(Subscriber subscriber, Guid id)
    {
        try
        {
            await _lessonsRepository.Update(subscriber, id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при обновлении данных: {ex}");
        }
    }

    public async Task<Result<List<Subscriber>>> GetAllSubscribers()
    {
        try
        {
            List<Subscriber> sub = await _lessonsRepository.GetAllSubscribers();
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Subscriber>>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<Subscriber>> GetByGuidSubscriber(Guid id)
    {
        try
        {
            Subscriber sub = await _lessonsRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<Subscriber>($"Ошибка при получении абонента: {ex}");
        }
    }
}
