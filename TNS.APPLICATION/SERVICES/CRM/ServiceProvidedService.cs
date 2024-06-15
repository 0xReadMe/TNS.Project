using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.SERVICES.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.APPLICATION.SERVICES.CRM;

public class ServiceProvidedService : IServiceProvidedService
{
    public Task<Result> AddServiceProvided(ServiceProvided service)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteServiceProvided(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<ServiceProvided>>> GetAllServiceProvided()
    {
        throw new NotImplementedException();
    }

    public Task<Result<ServiceProvided>> GetByGuidServiceProvided(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateServiceProvided(ServiceProvided service, Guid id)
    {
        throw new NotImplementedException();
    }
}
