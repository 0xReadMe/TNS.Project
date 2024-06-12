using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.MODELS.CRM;

namespace TNS.PERSISTENCE.REPOSITORIES.CRM;

public class CRMRepository : ICRMRepository
{
    public Task Add(CRM_request CRM)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CRM_request>> GetAllCRM_Requests()
    {
        throw new NotImplementedException();
    }

    public Task<CRM_request> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(CRM_request CRM, Guid id)
    {
        throw new NotImplementedException();
    }
}
