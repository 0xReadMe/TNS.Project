using TNS.CORE.MODELS.CRM;
namespace TNS.CORE.INTERFACES.REPOSITORY.CRM;
public interface IServiceRepository
{
    Task Add(Service service);
    Task Delete(Guid id);
    Task Update(Service service, Guid id);
    Task<Service> GetByGuid(Guid id);
    Task<List<Service>> GetAllServices();
}
