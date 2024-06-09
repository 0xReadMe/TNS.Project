namespace TNS.PERSISTENCE.ENTITIES;

public class EventEntity
{
    public required Guid                    Id          { get; set; }                   //  id события
    public required Guid                    PositionId  { get; set; }                   //  id должности
    public required DateOnly                Date        { get; set; }                   //  дата события
    public          string                  Description { get; set; } = string.Empty;   //  описание события
    public required TimeOnly                Time        { get; set; }                   //  время события

    public ICollection<EmployeePositionEntity> employeePositions { get; set; } = [];
}
