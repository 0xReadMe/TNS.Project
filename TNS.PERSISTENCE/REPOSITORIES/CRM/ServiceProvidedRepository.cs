using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.MODELS.CRM;
using TNS.PERSISTENCE.ENTITIES.CRM;

namespace TNS.PERSISTENCE.REPOSITORIES.CRM;

public class ServiceProvidedRepository(TNSDbContext context, IMapper mapper) : IServiceProvidedRepository
{
    private readonly TNSDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task Add(ServiceProvided serviceProvided)
    {
        var service = new ServiceProvidedEntity()
        {
            Id      = serviceProvided.Id,
            Name    = serviceProvided.Name
        };

        await _context.ServiceProvided.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) => await _context.ServiceProvided.Where(l => l.Id == id).ExecuteDeleteAsync();

    public async Task<List<ServiceProvided>> GetAllServicesProvided()
    {
        List<ServiceProvided> crm = [];

        await foreach (var s in _context.ServiceProvided)
        {
            crm.Add(_mapper.Map<ServiceProvided>(s));
        }
        return crm;
    }

    public async Task<ServiceProvided> GetByGuid(Guid id)
    {
        var crm = await _context.ServiceProvided.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        return _mapper.Map<ServiceProvided>(crm);
    }

    public async Task Update(ServiceProvided serviceProvided, Guid id)
    {
        var result = await _context.ServiceProvided
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Name, serviceProvided.Name));
    }
}
