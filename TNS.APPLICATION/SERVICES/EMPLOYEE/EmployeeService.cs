using CSharpFunctionalExtensions;
using TNS.APPLICATION.Auth;
using TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;
using TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;
using TNS.CORE.INTERFACES.SERVICES.EMPLOYEE;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.MODELS.SUBSCRIBER;
using TNS.CORE.VO;

namespace TNS.APPLICATION.SERVICES.EMPLOYEE
{
    public class EmployeeService(
        IEmployeeRepository employeeRepository
            //IPasswordHasher     passwordHasher, 
            //IJWTProvider        jwtProvider
            ) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        public async Task<Result> AddEmployee(Employee employee)
        {
            try
            {
                await _employeeRepository.Add(employee);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Ошибка при добавлении: {ex}");
            }
        }

        public async Task<Result> DeleteEmployee(Guid id)
        {
            try
            {
                await _employeeRepository.Delete(id);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Ошибка при удалении: {ex}");
            }
        }

        public async Task<Result<List<Employee>>> GetAllEmployees()
        {
            try
            {
                List<Employee> sub = await _employeeRepository.GetAllEmployees();
                return Result.Success(sub);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<Employee>>($"Ошибка при получении данных: {ex}");
            }
        }

        public async Task<Result<Employee>> GetEmployeeByGuid(Guid id)
        {
            try
            {
                Employee sub = await _employeeRepository.GetByGuid(id);
                return Result.Success(sub);
            }
            catch (Exception ex)
            {
                return Result.Failure<Employee>($"Ошибка при получении данных: {ex}");
            }
        }

        public async Task Login(string phoneNumber, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> UpdateEmployee(Employee employee, Guid id)
        {
            try
            {
                await _employeeRepository.Update(employee, id);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Ошибка при обновлении данных: {ex}");
            }
        }
    }
}
