namespace TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

public class PermissionEntity
{
    public int      Id      { get; set; }
    public string   Name    { get; set; } = string.Empty;

    public ICollection<RoleEntity> Roles { get; set; } = [];
}
