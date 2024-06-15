using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.MODELS.EQUIPMENT;
using TNS.PERSISTENCE.ENTITIES.EQUIPMENT;

namespace TNS.PERSISTENCE.REPOSITORIES.EQUIPMENT;

public class EquipmentRepository(TNSDbContext context, IMapper mapper) : IEquipmentRepository
{
    private readonly TNSDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task Add(Equipment equipment)
    {
        var equipmentEntity = new EquipmentEntity()
        {
            Id = equipment.Id,
            SerialNumber = equipment.SerialNumber,
            Name= equipment.Name,
            Frequency = equipment.Frequency,
            AttenuationCoefficient = equipment.AttenuationCoefficient,
            DTT = equipment.DTT,
            Address = equipment.Address,
            IsWorking = equipment.IsWorking
        };

        await _context.Equipments.AddAsync(equipmentEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) => await _context.Equipments.Where(l => l.Id == id).ExecuteDeleteAsync();

    public async Task<List<Equipment>> GetAllEquipment()
    {
        List<Equipment> eq = [];

        await foreach (var s in _context.Equipments)
        {
            eq.Add(_mapper.Map<Equipment>(s));
        }
        return eq;
    }

    public async Task<Equipment> GetByGuid(Guid id)
    {
        var equipmentEntity = await _context.Equipments.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        return _mapper.Map<Equipment>(equipmentEntity);
    }

    public async Task Update(Equipment equipment, Guid id)
    {
        var result = await _context.Equipments
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Address, equipment.Address)
                .SetProperty(p => p.Frequency, equipment.Frequency)
                .SetProperty(p => p.AttenuationCoefficient, equipment.AttenuationCoefficient)
                .SetProperty(p => p.SerialNumber, equipment.SerialNumber)
                .SetProperty(p => p.DTT, equipment.DTT)
                .SetProperty(p => p.Name, equipment.Name)
                );
    }
}
