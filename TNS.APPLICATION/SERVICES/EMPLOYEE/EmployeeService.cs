using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;
using TNS.CORE.INTERFACES.SERVICES.EMPLOYEE;
using TNS.CORE.MODELS.EMPLOYEE;
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

        public async Task<Result> AddEmployee(Employee employee, int roleId)
        {
            try
            {
                await _employeeRepository.Add(employee, roleId);
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

        public async Task<Result<int>> GetRoleId(Guid id)
        {
            try
            {
                int sub = (await _employeeRepository.GetRoleId(id)).Value;
                return Result.Success(sub);
            }
            catch (Exception ex)
            {
                return Result.Failure<int>($"Ошибка при получении данных: {ex}");
            }
        }

        public async Task<Result<Employee>> GetEmployeeByGuid(Guid id)
        {
            try
            {
                Employee sub = await _employeeRepository.GetByGuid(id);
                if (sub != null)
                {
                    return Result.Success(sub);
                }
                else 
                {
                    return Result.Failure<Employee>($"Поиск вернул пустого сотрудника");

                }
            }
            catch (Exception ex)
            {
                return Result.Failure<Employee>($"Ошибка при получении данных: {ex}");
            }
        }

        public async Task<Result<Employee>> Login(PhoneNumber phoneNumber, string password)
        {
            try
            {
                Employee sub = await _employeeRepository.GetByLogin(phoneNumber);
                if (sub != null)
                {
                    if (sub.Password == password) 
                    {
                        return Result.Success(sub);
                    }
                    else 
                    {
                        return Result.Failure<Employee>($"Invalid Password");
                    }
                }
                else
                {
                    return Result.Failure<Employee>($"Invalid Login");

                }
            }
            catch (Exception ex)
            {
                return Result.Failure<Employee>($"Ошибка при получении данных: {ex}");
            }
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
