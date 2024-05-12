using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    public class Employee
    {
        public Guid     Id          { get; }    //  id сотрудника
        public string   FullName    { get; }    //  ФИО сотрудника
        public Guid     PositionId  { get; }    //  id должности
        public string?  PhotoId     { get; }    //  путь к фото

        private Employee(Guid       id,
                         Guid       positionId,
                         string     fullName,
                         string?    photoId)
        {
            Id          = id;
            FullName    = fullName; 
            PositionId  = positionId; 
            PhotoId     = photoId;
        }

        public static Result<Employee> Create(Guid      id,
                                              Guid      positionId,
                                              string    fullName,
                                              string?   photoId)
        {
            Employee result = new Employee(id,
                                           positionId,
                                           fullName,
                                           photoId);

            return Result.Success(result);
        }
    }
}