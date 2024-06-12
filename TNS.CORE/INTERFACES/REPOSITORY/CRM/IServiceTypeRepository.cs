using TNS.CORE.MODELS.CRM;

namespace TNS.CORE.INTERFACES.REPOSITORY.CRM;

public interface IServiceTypeRepository
{
    Task Add(ServiceType serviceType);
    Task Delete(Guid id);
    Task Update(ServiceType serviceType, Guid id);
    Task<ServiceType> GetByGuid(Guid id);
    Task<List<ServiceType>> GetAllServiceTypes();
}
