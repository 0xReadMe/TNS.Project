using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.CRM;

namespace TNS.CORE.INTERFACES.SERVICES.CRM;

public interface ICRMService
{
    Task<Result> AddCRM(CRM_request CRM);
    Task<Result> DeleteCRM(Guid id);
    Task<Result> UpdateCRM(CRM_request CRM, Guid id);
    Task<Result<CRM_request>> GetByGuidCRM(Guid id);
    Task<Result<List<CRM_request>>> GetAllCRM_Requests();
    Task<bool> TestCRMEquipment();
}
