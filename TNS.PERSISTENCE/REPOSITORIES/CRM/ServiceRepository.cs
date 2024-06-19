using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.MODELS.CRM;
using TNS.PERSISTENCE.ENTITIES.CRM;

namespace TNS.PERSISTENCE.REPOSITORIES.CRM;

public class ServiceRepository(TNSDbContext context, IMapper mapper) : IServiceRepository
{
    private readonly TNSDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task Add(Service serviceProvided)
    {
        var service = new ServiceEntity()
        {
            Id = serviceProvided.Id,
            Name = serviceProvided.Name
        };

        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) => await _context.Services.Where(l => l.Id == id).ExecuteDeleteAsync();

    public async Task<List<Service>> GetAllServices()
    {
        List<Service> crm = [];

        await foreach (var s in _context.Services)
        {
            crm.Add(_mapper.Map<Service>(s));
        }
        return crm;
    }

    public async Task<Service> GetByGuid(Guid id)
    {
        var crm = await _context.Services.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        return _mapper.Map<Service>(crm);
    }

    public async Task Update(Service service, Guid id)
    {
        var result = await _context.Services
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Name, service.Name));
    }
}
