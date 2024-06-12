using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.PERSISTENCE.REPOSITORIES.CRM;

public class ServiceTypeRepository : IServiceTypeRepository
{
    public Task Add(ServiceType serviceType)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceType>> GetAllServiceTypes()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceType> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(ServiceType serviceType, Guid id)
    {
        throw new NotImplementedException();
    }
}
