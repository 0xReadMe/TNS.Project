using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;
using TNS.CORE.MODELS.SUBSCRIBER;
using TNS.PERSISTENCE.ENTITIES.SUBSCRIBER;

namespace TNS.PERSISTENCE.REPOSITORIES.SUBSCRIBER;

public class PersonRepository(TNSDbContext context, IMapper mapper) : IPersonRepository
{
    private readonly TNSDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task Add(Person person)
    {
        var personEntity = new PersonEntity()
        {
            Id = person.Id,
            SubscriberId = person.SubscriberId,
            FirstName = person.FirstName,
            LastName = person.LastName,
            MiddleName = person.MiddleName,
            Gender = person.Gender,
            DOB = person.DOB,
            PhoneNumber = person.PhoneNumber,
            Email = person.Email,
            Passport = person.Passport,
        };

        await _context.Persons.AddAsync(personEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) => await _context.Persons.Where(l => l.Id == id).ExecuteDeleteAsync();

    public async Task<List<Person>> GetAllPersons()
    {
        List<Person> persons = [];

        await foreach (var s in _context.Persons)
        {
            persons.Add(_mapper.Map<Person>(s));
        }
        return persons;
    }

    public async Task<Person> GetByGuid(Guid id)
    {
        var personEntity = await _context.Persons.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        return _mapper.Map<Person>(personEntity);
    }

    public async Task Update(Person person, Guid id)
    {
        var result = await _context.Persons
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.DOB, person.DOB)
                .SetProperty(p => p.Email, person.Email)
                .SetProperty(p => p.FirstName, person.FirstName)
                .SetProperty(p => p.MiddleName, person.MiddleName)
                .SetProperty(p => p.LastName, person.LastName)
                .SetProperty(p => p.Gender, person.Gender)
                .SetProperty(p => p.PhoneNumber, person.PhoneNumber));

        // Обновляйте неподдерживаемое свойство (Passport) отдельно
        var personEntity = await _context.Persons.FindAsync(id);
        if (personEntity != null)
        {
            personEntity.Passport = person.Passport;
            await _context.SaveChangesAsync();
        }
    }
}
