using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.MODELS.SUBSCRIBER;

namespace TNS.CORE.INTERFACES.SERVICES.EMPLOYEE;

public interface IEmployeeService
{
    Task Login(string phoneNumber, string password);
    Task<Result> AddEmployee(Employee employee);
    Task<Result> DeleteEmployee(Guid id);
    Task<Result> UpdateEmployee(Employee employee, Guid id);
    Task<Result<Employee>> GetEmployeeByGuid(Guid id);
    Task<Result<List<Employee>>> GetAllEmployees();
}
