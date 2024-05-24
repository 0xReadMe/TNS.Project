namespace TNS.PERSISTENCE.ENTITIES
{
    public class EmployeeEntity
    {
        public Guid     Id          { get; set; }                   //  id сотрудника
        public Guid     PositionId  { get; set; }                   //  id должности
        public string   FullName    { get; set; }                   //  ФИО сотрудника
        public string   PhotoId     { get; set; } = string.Empty;   //  путь к фото
        public string   Login       { get; set; }                   //  авторизация
        public string   PasswordHash{ get; set; }                   //  авторизация
    }
}
