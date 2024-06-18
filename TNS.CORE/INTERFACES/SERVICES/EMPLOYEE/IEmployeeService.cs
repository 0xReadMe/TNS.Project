using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.VO;

namespace TNS.CORE.INTERFACES.SERVICES.EMPLOYEE;

public interface IEmployeeService
{
    Task<Result<Employee>> Login(PhoneNumber phoneNumber, string password);
    Task<Result> AddEmployee(Employee employee, int roleId);
    Task<Result> DeleteEmployee(Guid id);
    Task<Result> UpdateEmployee(Employee employee, Guid id);
    Task<Result<Employee>> GetEmployeeByGuid(Guid id);
    Task<Result<List<Employee>>> GetAllEmployees();
    Task<Result<int>> GetRoleId(Guid id);
}
