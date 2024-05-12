using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    public class EmployeePosition 
    {
        public Guid     Id              { get; }    //  id должности
        public string   PositionName    { get; }    //  название должности

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
