using AutoMapper;
using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.MODELS.EQUIPMENT;
using TNS.PERSISTENCE.ENTITIES.EQUIPMENT;

namespace TNS.PERSISTENCE.REPOSITORIES.EQUIPMENT;

public class BaseStationRepository(TNSDbContext context, IMapper mapper) : IBaseStationRepository
{
    private readonly TNSDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task Add(BaseStation baseStation)
    {
        var equipmentEntity = new BaseStationEntity()
        {
            Id = baseStation.Id,
            AddressId = baseStation.AddressId,
            BaseStationName = baseStation.BaseStationName,
            S = baseStation.S,
            Frequency = baseStation.Frequency,
            TypeAntenna = baseStation.TypeAntenna,
            Handover = baseStation.Handover,
            CommunicationProtocol = baseStation.CommunicationProtocol,
            IsWorking = baseStation.IsWorking
        };

        await _context.BaseStations.AddAsync(equipmentEntity);
        await _context.SaveChangesAsync();
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
