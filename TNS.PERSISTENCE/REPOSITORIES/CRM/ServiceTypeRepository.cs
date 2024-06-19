using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.MODELS.CRM;
using TNS.PERSISTENCE.ENTITIES.CRM;

namespace TNS.PERSISTENCE.REPOSITORIES.CRM;

public class ServiceTypeRepository(TNSDbContext context, IMapper mapper) : IServiceTypeRepository
{
    private readonly TNSDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task Add(ServiceType serviceType)
    {
        var service = new ServiceEntity()
        {
            Id      = serviceType.Id,
            Name    = serviceType.Name
        };

        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) => await _context.ServiceTypes.Where(l => l.Id == id).ExecuteDeleteAsync();

    public async Task<List<ServiceType>> GetAllServiceTypes()
    {
        List<ServiceType> crm = [];

        await foreach (var s in _context.ServiceTypes)
        {
            crm.Add(_mapper.Map<ServiceType>(s));
        }
        return crm;
    }

    public async Task<ServiceType> GetByGuid(Guid id)
    {
        var crm = await _context.ServiceTypes.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        return _mapper.Map<ServiceType>(crm);
    }

    public async Task Update(ServiceType serviceType, Guid id)
    {
        var result = await _context.ServiceTypes
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Name, serviceType.Name));
    }
}
