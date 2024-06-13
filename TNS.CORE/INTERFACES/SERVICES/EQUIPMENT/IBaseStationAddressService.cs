using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.CORE.INTERFACES.SERVICES.EQUIPMENT;

public interface IBaseStationAddressService
{
    Task<Result> AddBaseStationAddress(BaseStationAddress baseStationAddress);
    Task<Result> DeleteBaseStationAddress(Guid id);
    Task<Result> UpdateBaseStationAddress(BaseStationAddress baseStationAddress, Guid id);
    Task<Result<BaseStationAddress>> GetByGuidBaseStationAddress(Guid id);
    Task<Result<List<BaseStationAddress>>> GetAllBaseStationAddresses();
}
