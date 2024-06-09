namespace TNS.PERSISTENCE.ENTITIES;

public class EmployeePositionEntity
{
    public required Guid    Id              { get; set; }    //  id должности
    public required string  PositionName    { get; set; }    //  название должности

    public ICollection<EmployeeEntity> Employees { get; set; } = [];
    public ICollection<EventEntity> Events { get; set; } = [];
}