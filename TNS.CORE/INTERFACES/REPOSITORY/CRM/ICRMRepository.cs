using TNS.CORE.MODELS.CRM;
namespace TNS.CORE.INTERFACES.REPOSITORY.CRM;
public interface ICRMRepository
{
    Task Add(CRM_request CRM);
    Task Delete(Guid id);
    Task Update(CRM_request CRM, Guid id);
    Task<CRM_request> GetByGuid(Guid id);
    Task<List<CRM_request>> GetAllCRM_Requests();
}
