using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.MODELS.CRM;
using TNS.PERSISTENCE.ENTITIES.CRM;

namespace TNS.PERSISTENCE.REPOSITORIES.CRM;

public class CRMRepository(TNSDbContext context, IMapper mapper) : ICRMRepository
{
    private readonly TNSDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task Add(CRM_request CRM)
    {
        var crm = new CRM_requestEntity()
        {
            Id = CRM.Id,
            SubscriberId = CRM.SubscriberId,
            CreationDate = CRM.CreationDate,
            ClosingDate = CRM.ClosingDate,
            ServiceId = CRM.ServiceId,
            ServiceProvidedId = CRM.ServiceProvidedId,
            ServiceTypeId = CRM.ServiceTypeId,
            Status = CRM.Status,
            TypeOfProblem = CRM.TypeOfProblem,
            ProblemDescription = CRM.ProblemDescription
        };

        await _context.CRM_Requests.AddAsync(crm);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) => await _context.CRM_Requests.Where(l => l.Id == id).ExecuteDeleteAsync();

    public async Task<List<CRM_request>> GetAllCRM_Requests()
    {
        List<CRM_request> crm = [];

        await foreach (var s in _context.CRM_Requests)
        {
            crm.Add(_mapper.Map<CRM_request>(s));
        }
        return crm;
    }

    public async Task<CRM_request> GetByGuid(Guid id)
    {
        var crm = await _context.CRM_Requests.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        return _mapper.Map<CRM_request>(crm);
    }

    public async Task Update(CRM_request CRM, Guid id)
    {
        var result = await _context.CRM_Requests
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Status, CRM.Status)
                .SetProperty(p => p.ServiceId, CRM.ServiceId)
                .SetProperty(p => p.ServiceProvidedId, CRM.ServiceProvidedId)
                .SetProperty(p => p.ServiceTypeId, CRM.ServiceTypeId)
                .SetProperty(p => p.SubscriberId, CRM.SubscriberId)
                .SetProperty(p => p.ClosingDate, CRM.ClosingDate)
                .SetProperty(p => p.CreationDate, CRM.CreationDate)
                .SetProperty(p => p.TypeOfProblem, CRM.TypeOfProblem)
                .SetProperty(p => p.ProblemDescription, CRM.ProblemDescription)
                );
                
    }
}
