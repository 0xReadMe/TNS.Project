using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.PERSISTENCE.REPOSITORIES.CRM;

public class ServiceRepository : IServiceRepository
{
    public Task Add(Service service)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Service>> GetAllServices()
    {
        throw new NotImplementedException();
    }

    public Task<Service> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Service service, Guid id)
    {
        throw new NotImplementedException();
    }
}
