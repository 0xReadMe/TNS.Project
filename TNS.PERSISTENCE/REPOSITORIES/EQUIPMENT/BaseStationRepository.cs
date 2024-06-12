using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.PERSISTENCE.REPOSITORIES.EQUIPMENT;

public class BaseStationRepository : IBaseStationRepository
{
    public Task Add(BaseStation baseStation)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BaseStation>> GetAllBaseStations()
    {
        throw new NotImplementedException();
    }

    public Task<BaseStation> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(BaseStation baseStation, Guid id)
    {
        throw new NotImplementedException();
    }
}
