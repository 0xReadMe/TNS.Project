namespace TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

public class RoleEntity
{
    public int      Id      { get; set; }
    public string   Name    { get; set; } = string.Empty;

    public ICollection<PermissionEntity> Permissions { get; set; } = [];
    public ICollection<EmployeeEntity> Employees { get; set; } = [];
    public ICollection<EventEntity> Events { get; set; } = [];
}
