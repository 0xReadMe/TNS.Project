using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    public class Employee
    {
        public Guid     Id          { get; }    //  id сотрудника
        public string   FullName    { get; }    //  ФИО сотрудника
        public Guid     PositionId  { get; }    //  id должности
        public string?  PhotoId     { get; }    //  путь к фото

        public Employee()
        {

        }

        public static Result<Employee> Create()
        {
            Employee result = new Employee();

            return Result.Success(result);
        }
    }
}