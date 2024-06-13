using TNS.CORE.VO;

namespace TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

public class EmployeeEntity
{
    public required Guid                    Id          { get; set; }                   //  id сотрудника
    public required string                  FullName    { get; set; }                   //  ФИО сотрудника
    public required string                  PhotoId     { get; set; }                   //  путь к фото
    public required DateOnly                DateOfBirth { get; set; }                   //  дата рождения
    public          string                  Telegram    { get; set; } = string.Empty;   //  telegram
    public required Email                   Email       { get; set; }                   //  e-mail
    public required PhoneNumber             Login       { get; set; }                   //  авторизация
    public required string                  PasswordHash{ get; set; }                   //  авторизация

    public ICollection<RoleEntity> Roles { get; set; } = [];
}
