using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.CRM;

namespace TNS.CORE.INTERFACES.SERVICES.CRM;

public interface IServiceProvidedService
{
    Task<Result> AddServiceProvided(ServiceProvided service);
    Task<Result> DeleteServiceProvided(Guid id);
    Task<Result> UpdateServiceProvided(ServiceProvided service, Guid id);
    Task<Result<ServiceProvided>> GetByGuidServiceProvided(Guid id);
    Task<Result<List<ServiceProvided>>> GetAllServiceProvided();
}
