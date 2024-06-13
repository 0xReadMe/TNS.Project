using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.MODELS.SUBSCRIBER;
using TNS.CORE.VO;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.REPOSITORIES.EMPLOYEE
{
    public class EmployeeRepository(TNSDbContext context, IMapper mapper) : IEmployeeRepository
    {
        private readonly TNSDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task Add(Employee employee)
        {
            EmployeeEntity employeeEntity = new()
            {
                Id = employee.Id,
                PhotoId = employee.PhotoId,
                DateOfBirth = employee.DateOfBirth,
                Telegram = employee.Telegram,
                Email = employee.Email,
                Login = employee.Login,
                PasswordHash = employee.PasswordHash,
                FullName = employee.FullName
            };

            await _context.Employees.AddAsync(employeeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) => await _context.Employees.Where(l => l.Id == id).ExecuteDeleteAsync();

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = [];

            await foreach (var employeeEntity in _context.Employees)
            {
                employees.Add(_mapper.Map<Employee>(employeeEntity));
            }
            return employees;
        }

        public async Task<Employee> GetByGuid(Guid id)
        {
            var empEntity = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
            return _mapper.Map<Employee>(empEntity);
        }

        public async Task Update(Employee employee, Guid id)
        {
            await _context.Employees
            .Where(l => l.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(s => s.Email, employee.Email)
            .SetProperty(s => s.DateOfBirth, employee.DateOfBirth)
            .SetProperty(s => s.FullName, employee.FullName)
            .SetProperty(s => s.Login, employee.Login)
            .SetProperty(s => s.Telegram, employee.Telegram)
            .SetProperty(s => s.PhotoId, employee.PhotoId)
            );
        }

    }
}
