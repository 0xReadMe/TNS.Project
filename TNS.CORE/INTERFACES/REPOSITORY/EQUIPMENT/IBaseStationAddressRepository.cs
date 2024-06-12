using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;

public interface IBaseStationAddressRepository
{
    Task Add(BaseStationAddress baseStationAddress);
    Task Delete(Guid id);
    Task Update(BaseStationAddress baseStationAddress, Guid id);
    Task<BaseStationAddress> GetByGuid(Guid id);
    Task<List<BaseStationAddress>> GetAllBaseStationAddresses();
}
