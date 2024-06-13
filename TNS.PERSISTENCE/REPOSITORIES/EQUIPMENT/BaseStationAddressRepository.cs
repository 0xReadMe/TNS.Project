using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.MODELS;
using TNS.CORE.MODELS.EQUIPMENT;
using TNS.PERSISTENCE.ENTITIES.EQUIPMENT;

namespace TNS.PERSISTENCE.REPOSITORIES.EQUIPMENT;

public class BaseStationAddressRepository(TNSDbContext context, IMapper mapper) : IBaseStationAddressRepository
{
    private readonly TNSDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task Add(BaseStationAddress baseStationAddress)
    {
        var equipmentEntity = new BaseStationAddressEntity()
        {
            Id = baseStationAddress.Id,
            Address = baseStationAddress.Address,
            Location = baseStationAddress.Location
        };

        await _context.BaseStationAddresses.AddAsync(equipmentEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) => await _context.BaseStationAddresses.Where(l => l.Id == id).ExecuteDeleteAsync();

    public async Task<List<BaseStationAddress>> GetAllBaseStationAddresses()
    {
        List<BaseStationAddress> eq = [];

        await foreach (var s in _context.BaseStationAddresses)
        {
            eq.Add(_mapper.Map<BaseStationAddress>(s));
        }
        return eq;
    }

    public async Task<BaseStationAddress> GetByGuid(Guid id)
    {
        var equipmentEntity = await _context.BaseStationAddresses.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        return _mapper.Map<BaseStationAddress>(equipmentEntity);
    }

    public async Task Update(BaseStationAddress baseStationAddress, Guid id)
    {
        var result = await _context.BaseStationAddresses
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Address, baseStationAddress.Address)
                .SetProperty(p => p.Location, baseStationAddress.Location)
                );
    }
}
