using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.SERVICES.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.APPLICATION.SERVICES.CRM;

public class ServiceService : IServiceService
{
    public Task<Result> AddService(Service service)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteService(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Service>>> GetAllService()
    {
        throw new NotImplementedException();
    }

    public Task<Result<Service>> GetByGuidService(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateService(Service service, Guid id)
    {
        throw new NotImplementedException();
    }
}
