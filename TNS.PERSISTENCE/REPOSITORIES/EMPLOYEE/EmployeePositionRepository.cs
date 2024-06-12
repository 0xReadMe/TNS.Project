using TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;
using TNS.CORE.MODELS.EMPLOYEE;

namespace TNS.PERSISTENCE.REPOSITORIES.EMPLOYEE;

public class EmployeePositionRepository : IEmployeePositionRepository
{
    public Task Add(EmployeePosition employeePosition)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmployeePosition>> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeePosition> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(EmployeePosition employeePosition, Guid id)
    {
        throw new NotImplementedException();
    }
}
