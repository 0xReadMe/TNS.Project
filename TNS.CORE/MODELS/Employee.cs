using CSharpFunctionalExtensions;
using TNS.CORE.VO;

namespace TNS.CORE.MODELS
{
    public class Employee
    {
        public Guid         Id              { get; }    //  id сотрудника
        public string       FullName        { get; }    //  ФИО сотрудника
        public Guid         PositionId      { get; }    //  id должности
        public string?      PhotoId         { get; }    //  путь к фото
        public PhoneNumber  Login           { get; }    //  авторизация
        public string       PasswordHash    { get; }    //  авторизация

        private Employee(Guid           id,
                         Guid           positionId,
                         string         fullName,
                         string?        photoId,
                         PhoneNumber    login,
                         string         passwordHash)
        {
            Id              = id;
            FullName        = fullName; 
            PositionId      = positionId; 
            PhotoId         = photoId;
            Login           = login;
            PasswordHash    = passwordHash;
        }

        public static Result<Employee> Create(Guid          id,
                                              Guid          positionId,
                                              string        fullName,
                                              string?       photoId,
                                              PhoneNumber   login,
                                              string        passwordHash)
        {
            Employee result = new Employee(id,
                                           positionId,
                                           fullName,
                                           photoId,
                                           login,
                                           passwordHash);

            return Result.Success(result);
        }
    }
}