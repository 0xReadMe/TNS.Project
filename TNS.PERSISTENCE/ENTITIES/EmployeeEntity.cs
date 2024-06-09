using TNS.CORE.VO;

namespace TNS.PERSISTENCE.ENTITIES;

public class EmployeeEntity
{
    public required Guid                    Id          { get; set; }                   //  id сотрудника
    public required Guid                    PositionId  { get; set; }                   //  id должности
    public required EmployeePositionEntity  Position    { get; set; }                   //  for configuration
    public required string                  FullName    { get; set; }                   //  ФИО сотрудника
    public required string                  PhotoId     { get; set; }                   //  путь к фото
    public required DateOnly                DateOfBirth { get; set; }                   //  дата рождения
    public          string                  Telegram    { get; set; } = string.Empty;   //  telegram
    public required PhoneNumber             Login       { get; set; }                   //  авторизация
    public required string                  PasswordHash{ get; set; }                   //  авторизация
}
