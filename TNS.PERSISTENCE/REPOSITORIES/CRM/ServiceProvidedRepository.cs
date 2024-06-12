using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.PERSISTENCE.REPOSITORIES.CRM;

public class ServiceProvidedRepository : IServiceProvidedRepository
{
    public Task Add(ServiceProvided serviceProvided)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceProvided>> GetAllServicesProvided()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceProvided> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(ServiceProvided serviceProvided, Guid id)
    {
        throw new NotImplementedException();
    }
}
