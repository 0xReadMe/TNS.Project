namespace TNS.PERSISTENCE.ENTITIES;

public class BaseStationEntity
{
    public required Guid                     Id                      { get; set; }    //  id
    public required Guid                     AddressId               { get; set; }    //  id адреса станции
    public required BaseStationAddressEntity Address                 { get; set; }    //  for configuration
    public required string                   BaseStationName         { get; set; }    //  название БС
    public required double                   S                       { get; set; }    //  площадь зоны покрытия
    public required int                      Frequency               { get; set; }    //  частота, Гц
    public required string                   TypeAntenna             { get; set; }    //  тип антенны
    public required int                      Handover                { get; set; }    //  показатель хендовера
    public required string                   CommunicationProtocol   { get; set; }    //  стандарт связи
}
