using TNS.CORE.MODELS.EMPLOYEE;

namespace TNS.CORE.INTERFACES.SERVICES.EMPLOYEE;

public interface IEmployeeService
{
    Task Login(string phoneNumber, string password);
    Task AddEmployee(Employee employee);
    Task DeleteEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task GetEmployeeByGuid(Guid id);
}
