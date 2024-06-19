using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.INTERFACES.SERVICES.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.APPLICATION.SERVICES.CRM;

public class ServiceProvidedService(IServiceProvidedRepository crmRepository) : IServiceProvidedService
{
    public readonly IServiceProvidedRepository _serviceRepository = crmRepository;

    public async Task<Result> AddServiceProvided(ServiceProvided service)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> DeleteServiceProvided(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<ServiceProvided>>> GetAllServiceProvided()
    {
        try
        {
            List<ServiceProvided> sub = await _serviceRepository.GetAllServicesProvided();
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<ServiceProvided>>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<ServiceProvided>> GetByGuidServiceProvided(Guid id)
    {
        try
        {
            ServiceProvided sub = await _serviceRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<ServiceProvided>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result> UpdateServiceProvided(ServiceProvided service, Guid id)
    {
        throw new NotImplementedException();
    }
}
