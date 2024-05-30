using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    public class EmployeePosition 
    {
        private readonly List<Employee> _employees = [];

        public Guid     Id              { get; }    //  id должности
        public string   PositionName    { get; }    //  название должности

        public IReadOnlyList<Employee>? Employees => _employees;


        private EmployeePosition(Guid id,
                                 string positionName) 
        {
            Id              = id;
            PositionName    = positionName;
        }

        public static Result<EmployeePosition> Create(Guid id,
                                                      string positionName)
        {
            EmployeePosition result = new EmployeePosition(id,
                                                           positionName);

            return Result.Success(result);
        }
    }
}
