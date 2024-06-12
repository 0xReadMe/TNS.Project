using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;

public interface IBaseStationRepository
{
    Task Add(BaseStation baseStation);
    Task Delete(Guid id);
    Task Update(BaseStation baseStation, Guid id);
    Task<BaseStation> GetByGuid(Guid id);
    Task<List<BaseStation>> GetAllBaseStations();
}
