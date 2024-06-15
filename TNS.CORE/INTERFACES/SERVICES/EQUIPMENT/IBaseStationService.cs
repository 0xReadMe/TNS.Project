using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.CORE.INTERFACES.SERVICES.EQUIPMENT;

public interface IBaseStationService
{
    Task<Result> AddBaseStation(BaseStation baseStation);
    Task<Result> DeleteBaseStation(Guid id);
    Task<Result> UpdateBaseStation(BaseStation baseStation, Guid id);
    Task<Result<BaseStation>> GetByGuidBaseStation(Guid id);
    Task<Result<List<BaseStation>>> GetAllBaseStations();
    Task<Result<BaseStation>> TestBaseStation(Guid id);
    Task<Result<List<BaseStation>>> TestAllBaseStation();
}
