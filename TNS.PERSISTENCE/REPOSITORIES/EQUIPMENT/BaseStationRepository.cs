using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

    public async Task Delete(Guid id) => await _context.BaseStations.Where(l => l.Id == id).ExecuteDeleteAsync();

    public async Task<List<BaseStation>> GetAllBaseStations()
    {
        List<BaseStation> eq = [];

        await foreach (var s in _context.BaseStations)
        {
             BaseStation baseStation = BaseStation.Create(
                s.AddressId,
                s.BaseStationName,
                s.S,
                s.Frequency,
                s.TypeAntenna,
                s.Handover,
                s.CommunicationProtocol,
                s.IsWorking
                ).Value;
            BaseStation.AddGuid(baseStation, s.Id);
            eq.Add(baseStation);
        }
        return eq;
    }

    public async Task<BaseStation> GetByGuid(Guid id)
    {
        var s = await _context.BaseStations.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        BaseStation baseStation = BaseStation.Create(
                s.AddressId,
                s.BaseStationName,
                s.S,
                s.Frequency,
                s.TypeAntenna,
                s.Handover,
                s.CommunicationProtocol,
                s.IsWorking
                ).Value;
        return baseStation;
    }

    public async Task Update(BaseStation baseStation, Guid id)
    {
        var result = await _context.BaseStations
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.IsWorking, baseStation.IsWorking)
                .SetProperty(p => p.S, baseStation.S)
                .SetProperty(p => p.Frequency, baseStation.Frequency)
                .SetProperty(p => p.Handover, baseStation.Handover)
                .SetProperty(p => p.BaseStationName, baseStation.BaseStationName)
                .SetProperty(p => p.CommunicationProtocol, baseStation.CommunicationProtocol)
                .SetProperty(p => p.TypeAntenna, baseStation.TypeAntenna)
                //.SetProperty(p => p.AddressId, baseStation.AddressId)
                );
    }
}
