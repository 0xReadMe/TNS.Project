using TNS.CORE.MODELS;
using TNS.CORE.VO;

namespace TNS.CORE.INTERFACES.REPOSITORY
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
        Task<Employee> GetByPhone(PhoneNumber phone);
    }
}
