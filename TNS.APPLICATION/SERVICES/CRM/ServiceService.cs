using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.INTERFACES.SERVICES.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.APPLICATION.SERVICES.CRM;

public class ServiceService(IServiceRepository crmRepository) : IServiceService
{
    public readonly IServiceRepository _serviceRepository = crmRepository;

    public async Task<Result> AddService(Service service)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> DeleteService(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<Service>>> GetAllService()
    {
        try
        {
            List<Service> sub = await _serviceRepository.GetAllServices();
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Service>>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<Service>> GetByGuidService(Guid id)
    {
        try
        {
            Service sub = await _serviceRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<Service>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result> UpdateService(Service service, Guid id)
    { 
        throw new NotImplementedException();
    }
}
