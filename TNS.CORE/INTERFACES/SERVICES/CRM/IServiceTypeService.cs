using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.CRM;

namespace TNS.CORE.INTERFACES.SERVICES.CRM;

public interface IServiceTypeService
{
    Task<Result> AddServiceType(ServiceType service);
    Task<Result> DeleteServiceType(Guid id);
    Task<Result> UpdateServiceType(ServiceType service, Guid id);
    Task<Result<ServiceType>> GetByGuidServiceType(Guid id);
    Task<Result<List<ServiceType>>> GetAllServiceType();
}
