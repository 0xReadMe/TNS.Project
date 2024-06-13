using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;
using TNS.CORE.INTERFACES.SERVICES.SUBSCRIBER;
using TNS.CORE.MODELS.SUBSCRIBER;

namespace TNS.APPLICATION.SERVICES.SUBSCRIBER;

public class SubscriberService(ISubscriberRepository subscriberRepository) : ISubscriberService
{
    public readonly ISubscriberRepository _subscriberRepository = subscriberRepository;

    public async Task<Result> AddSubscriber(Subscriber s)
    {
        try 
        {
            await _subscriberRepository.Add(s);
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
            await _subscriberRepository.Delete(id);
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
            await _subscriberRepository.Update(subscriber, id);
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
            List<Subscriber> sub = await _subscriberRepository.GetAllSubscribers();
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
            Subscriber sub = await _subscriberRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<Subscriber>($"Ошибка при получении абонента: {ex}");
        }
    }
}
