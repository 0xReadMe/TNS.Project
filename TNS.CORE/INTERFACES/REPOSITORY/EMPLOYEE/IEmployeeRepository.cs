using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.VO;

namespace TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee, int roleId);
        Task Delete(Guid id);
        Task Update(Employee employee, Guid id);
        Task<Employee> GetByGuid(Guid id);
        Task<Employee> GetByLogin(PhoneNumber login);
        Task<int> GetRoleId(Guid id);
        Task<List<Employee>> GetAllEmployees();
    }
}
