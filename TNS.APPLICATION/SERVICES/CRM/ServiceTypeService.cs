using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.INTERFACES.SERVICES.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.APPLICATION.SERVICES.CRM;

public class ServiceTypeService(IServiceTypeRepository crmRepository) : IServiceTypeService
{
    public readonly IServiceTypeRepository _serviceRepository = crmRepository;

    public async Task<Result> AddServiceType(ServiceType service)
    {
        try
        {
            await _serviceRepository.Add(service);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при добавлении: {ex}");
        }
    }

    public async Task<Result> DeleteServiceType(Guid id)
    {
        try
        {
            await _serviceRepository.Delete(id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при удалении: {ex}");
        }
    }

    public async Task<Result<List<ServiceType>>> GetAllServiceType()
    {
        try
        {
            List<ServiceType> sub = await _serviceRepository.GetAllServiceTypes();
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<ServiceType>>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<ServiceType>> GetByGuidServiceType(Guid id)
    {
        try
        {
            ServiceType sub = await _serviceRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<ServiceType>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result> UpdateServiceType(ServiceType service, Guid id)
    {
        try
        {
            await _serviceRepository.Update(service, id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при обновлении данных: {ex}");
        }
    }
}
