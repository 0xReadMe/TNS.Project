using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.SERVICES.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.APPLICATION.SERVICES.CRM;

public class ServiceTypeService : IServiceTypeService
{
    public Task<Result> AddServiceType(ServiceType service)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteServiceType(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<ServiceType>>> GetAllServiceType()
    {
        throw new NotImplementedException();
    }

    public Task<Result<ServiceType>> GetByGuidServiceType(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateServiceType(ServiceType service, Guid id)
    {
        throw new NotImplementedException();
    }
}
