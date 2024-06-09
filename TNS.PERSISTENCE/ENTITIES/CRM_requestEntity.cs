namespace TNS.PERSISTENCE.ENTITIES;

public class CRM_requestEntity
{
    public required Guid                    Id                  { get; set; }       //  id заявки
    public required Guid                    SubscriberId        { get; set; }       //  лицевой счет + номер абонента + тип оборудования
    public required DateOnly                CreationDate        { get; set; }       //  дата создания
    public required DateOnly                ClosingDate         { get; set; }       //  дата закрытия заявки
    public required Guid                    ServiceId           { get; set; }       //  услуга
    public required Guid                    ServiceProvidedId   { get; set; }       //  оказываемая услуга
    public required Guid                    ServiceTypeId       { get; set; }       //  тип услуги
    public required string                  Status              { get; set; }       //  статус услуги
    public required string                  TypeOfProblem       { get; set; }       //  тип проблемы
    public required string                  ProblemDescription  { get; set; }       //  описание услуги

    public required SubscriberEntity        Subscriber          { get; set; }       //  for configuration
    public required ServiceEntity           Service             { get; set; }       //  for configuration
    public required ServiceProvidedEntity   ServiceProvided     { get; set; }       //  for configuration
    public required ServiceTypeEntity       ServiceType         { get; set; }       //  for configuration
}