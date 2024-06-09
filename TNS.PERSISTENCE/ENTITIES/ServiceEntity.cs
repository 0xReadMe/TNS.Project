namespace TNS.PERSISTENCE.ENTITIES;

public class ServiceEntity
{
    public required Guid    Id      { get; set; }    //  id услуги
    public required string  Name    { get; set; }    //  имя услуги

    public ICollection<CRM_requestEntity> CRM_RequestEntities { get; set; } = [];
}
