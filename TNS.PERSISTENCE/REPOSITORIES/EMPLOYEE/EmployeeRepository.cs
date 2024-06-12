using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.VO;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.REPOSITORIES.EMPLOYEE
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TNSDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(TNSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(Employee employee)
        {
            EmployeeEntity employeeEntity = new()
            {
                Id = employee.Id,
                PositionId = employee.PositionId,
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

        public async Task<Result> Delete(Guid guid)
        {
            var employee = await _context.Employees.FindAsync(guid);
            if (employee == null)
            {
                return Result.Failure("Попытка удаления не удалась. Сотрудник не был найден.");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Result.Success();
        }


        public Task<List<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetByPhone(PhoneNumber phone)
        {
            var employeeEntity = await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(emp => emp.Login == phone) ?? throw new Exception();

            return _mapper.Map<Employee>(employeeEntity);
        }

        public Task Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task Update(Employee employee, Guid id)
        {
            throw new NotImplementedException();
        }

        Task IEmployeeRepository.Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
