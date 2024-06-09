namespace TNS.PERSISTENCE.ENTITIES;

public class BaseStationAddressEntity
{
    public Guid     Id          { get; set; }                   //  id
    public string   Address     { get; set; } = string.Empty;   //  адрес площадки
    public string   Location    { get; set; } = string.Empty;   //  место расположения

    public ICollection<BaseStationEntity> BaseStations { get; set; } = [];
}