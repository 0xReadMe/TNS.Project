using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.MODELS;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.PERSISTENCE.REPOSITORIES.EQUIPMENT;

public class BaseStationAddressRepository : IBaseStationAddressRepository
{
    public Task Add(BaseStationAddress baseStationAddress)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BaseStationAddress>> GetAllBaseStationAddresses()
    {
        throw new NotImplementedException();
    }

    public Task<BaseStationAddress> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(BaseStationAddress baseStationAddress, Guid id)
    {
        throw new NotImplementedException();
    }
}
