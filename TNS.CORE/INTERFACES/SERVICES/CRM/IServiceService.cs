using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.CRM;

namespace TNS.CORE.INTERFACES.SERVICES.CRM;

public interface IServiceService
{
    Task<Result> AddService(Service service);
    Task<Result> DeleteService(Guid id);
    Task<Result> UpdateService(Service service, Guid id);
    Task<Result<Service>> GetByGuidService(Guid id);
    Task<Result<List<Service>>> GetAllService();
}