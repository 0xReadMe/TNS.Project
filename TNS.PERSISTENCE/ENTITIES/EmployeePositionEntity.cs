using TNS.CORE.MODELS;

namespace TNS.PERSISTENCE.ENTITIES
{
    public class EmployeePositionEntity
    {
        public Guid Id { get; set; }    //  id должности
        public string PositionName { get; set; }    //  название должности

        public ICollection<EmployeeEntity> Employees { get; set; } = [];

    }
}