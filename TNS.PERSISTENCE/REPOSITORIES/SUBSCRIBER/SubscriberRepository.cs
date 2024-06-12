using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;
using TNS.CORE.MODELS.SUBSCRIBER;
using TNS.PERSISTENCE.ENTITIES.SUBSCRIBER;

namespace TNS.PERSISTENCE.REPOSITORIES.SUBSCRIBER
{
    public class SubscriberRepository(TNSDbContext context, IMapper mapper) : ISubscriberRepository
    {
        private readonly TNSDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task Add(Subscriber s)
        {
            var subscriber = new SubscriberEntity()
            {
                SubscriberNumber = s.SubscriberNumber,
                Id = s.Id,
                ContractNumber = s.ContractNumber,
                DateOfContractConclusion = s.DateOfContractConclusion,
                DateOfTerminationOfTheContract = s.DateOfTerminationOfTheContract,
                ContractType = s.ContractType,
                ReasonForTerminationOfContract = s.ReasonForTerminationOfContract,
                PersonalBill = s.PersonalBill,
                Services = s.Services,
                TypeOfEquipment = s.TypeOfEquipment
            };

            await _context.Subscribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _context.Subscribers
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Subscriber>> GetAllSubscribers()
        {
            List<Subscriber> subscribers = [];

            await foreach(var s in _context.Subscribers) 
            {
                subscribers.Add(_mapper.Map<Subscriber>(s));
            }
            return subscribers;
        }

        public async Task<Subscriber> GetByGuid(Guid id)
        {
            var lessonEntity = await _context.Subscribers
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id);

            return _mapper.Map<Subscriber>(lessonEntity);
        }

        public async Task Update(Subscriber subscriber, Guid id)
        {
            await _context.Subscribers
            .Where(l => l.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(s => s.Services, subscriber.Services)
            .SetProperty(s => s.DateOfContractConclusion, subscriber.DateOfContractConclusion)
            .SetProperty(s => s.DateOfTerminationOfTheContract, subscriber.DateOfTerminationOfTheContract)
            .SetProperty(s => s.SubscriberNumber, subscriber.SubscriberNumber)
            .SetProperty(s => s.ContractType, subscriber.ContractType)
            .SetProperty(s => s.ReasonForTerminationOfContract, subscriber.ReasonForTerminationOfContract)
            .SetProperty(s => s.PersonalBill, subscriber.PersonalBill)
            .SetProperty(s => s.Services, subscriber.Services)
            .SetProperty(s => s.TypeOfEquipment, subscriber.TypeOfEquipment));
        }
    }
}
