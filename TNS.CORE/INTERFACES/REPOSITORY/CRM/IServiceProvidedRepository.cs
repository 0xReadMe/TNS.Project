using TNS.CORE.MODELS.CRM;

namespace TNS.CORE.INTERFACES.REPOSITORY.CRM;

public interface IServiceProvidedRepository
{
    Task Add(ServiceProvided serviceProvided);
    Task Delete(Guid id);
    Task Update(ServiceProvided serviceProvided, Guid id);
    Task<ServiceProvided> GetByGuid(Guid id);
    Task<List<ServiceProvided>> GetAllServicesProvided();
}
