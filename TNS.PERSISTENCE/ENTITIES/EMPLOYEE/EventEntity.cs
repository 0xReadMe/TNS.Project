namespace TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

public class EventEntity
{
    public required Guid Id { get; set; }                   //  id события
    public required DateOnly Date { get; set; }                   //  дата события
    public string Description { get; set; } = string.Empty;   //  описание события
    public required TimeOnly Time { get; set; }                   //  время события

    public ICollection<RoleEntity> Roles { get; set; } = [];
}
