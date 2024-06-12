using TNS.CORE.MODELS.EMPLOYEE;

namespace TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;

public interface IEmployeePositionRepository
{
    Task Add(EmployeePosition employeePosition);
    Task Delete(Guid id);
    Task Update(EmployeePosition employeePosition, Guid id);
    Task<EmployeePosition> GetByGuid(Guid id);
    Task<List<EmployeePosition>> GetAllEmployees();
}
