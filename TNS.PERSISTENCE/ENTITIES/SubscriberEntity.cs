namespace TNS.PERSISTENCE.ENTITIES;

public class SubscriberEntity
{
    public required Guid            Id                              { get; set; }           //  id абонента
    public required Guid            PersonId                        { get; set; }           //  id человека
    public required PersonEntity    Person                          { get; set; }           //  for configuration
    public required string          SubscriberNumber                { get; set; }           //  номер абонента
    public required string          ContractNumber                  { get; set; }           //  номер договора
    public required bool            ContractType                    { get; set; }           //  тип договора (true - с пролонгацией, false - без пролонгации)
    public required string          ReasonForTerminationOfContract  { get; set; }           //  причина расторжения договора
    public required uint            PersonalBill                    { get; set; }           //  лицевой счет
    public required string          Services                        { get; set; }           //  услуги
    public required DateOnly        DateOfContractConclusion        { get; set; }           //  дата заключения договора
    public required DateOnly        DateOfTerminationOfTheContract  { get; set; }           //  дата расторжения договора
    public required string          TypeOfEquipment                 { get; set; }           //  тип оборудования

    public ICollection<CRM_requestEntity> CRM_RequestEntities { get; set; } = [];
}