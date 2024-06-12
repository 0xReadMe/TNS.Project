namespace TNS.PERSISTENCE.ENTITIES.CRM;

public class ServiceProvidedEntity
{
    public required Guid Id { get; set; }    //  id услуги
    public required string Name { get; set; }    //  имя услуги

    public ICollection<CRM_requestEntity> CRM_RequestEntities { get; set; } = [];
}