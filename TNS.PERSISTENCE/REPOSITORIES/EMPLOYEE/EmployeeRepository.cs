using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.VO;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.REPOSITORIES.EMPLOYEE
{
    public class EmployeeRepository(TNSDbContext context, IMapper mapper) : IEmployeeRepository
    {
        private readonly TNSDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task Add(Employee employee, int roleId)
        {
            EmployeeEntity employeeEntity = new()
            {
                Id = employee.Id,
                PhotoId = employee.PhotoId,
                DateOfBirth = employee.DateOfBirth,
                Telegram = employee.Telegram,
                Email = employee.Email,
                Login = employee.Login,
                Password = employee.Password,
                FullName = employee.FullName
            };
            EmployeeRoleEntity roleEntity = new() { EmployeeId = employeeEntity.Id, RoleId = roleId };
            await _context.AddAsync(roleEntity);
            await _context.Employees.AddAsync(employeeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) 
        {
            await _context.Employees.Where(l => l.Id == id).ExecuteDeleteAsync();
        } 
        
        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = [];

            await foreach (var employeeEntity in _context.Employees)
            {
                Employee emp = Employee.Create(
                    employeeEntity.FullName,
                    employeeEntity.PhotoId,
                    employeeEntity.Telegram,
                    employeeEntity.DateOfBirth,
                    employeeEntity.Email,
                    employeeEntity.Login,
                    employeeEntity.Password).Value;
                
                emp.SetId(employeeEntity.Id);
                employees.Add(emp);
            }
            return employees;
        }

        public async Task<Employee> GetByGuid(Guid id)
        {
            var empEntity = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
            return _mapper.Map<Employee>(empEntity);
        }

        public async Task<Result<int>> GetRoleId(Guid id)
        {
            try
            {
                using var connection = _context.Database.GetDbConnection();
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                using var command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT r.""Id""
                    FROM ""EmployeeRoleEntity"" er
                    JOIN ""Roles"" r ON er.""RoleId"" = r.""Id""
                    WHERE er.""EmployeeId"" = @employeeId
                    LIMIT 1";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@employeeId";
                parameter.Value = id;
                parameter.DbType = DbType.Guid;
                command.Parameters.Add(parameter);

                var result = await command.ExecuteScalarAsync();
                await connection.CloseAsync();
                if (result != null)
                {
                    return Result.Success((int)result);
                }
                else
                {
                    return Result.Failure<int>("No role found for the given employee ID.");
                }
            }
            catch (Exception ex)
            {
                // Обрабатываем другие исключения
                return Result.Failure<int>($"Error getting role ID: {ex.Message}");
            }
        }

        public async Task<Employee> GetByLogin(PhoneNumber login)
        {
            var empEntity = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(l => l.Login == login);
            return _mapper.Map<Employee>(empEntity);
        }

        public async Task Update(Employee employee, Guid id)
        {
            Employee emp = Employee.Create(
                    employee.FullName,
                    employee.PhotoId,
                    employee.Telegram,
                    employee.DateOfBirth,
                    employee.Email,
                    employee.Login,
                    employee.Password).Value;

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