namespace TNS.PERSISTENCE.ENTITIES;

public class EquipmentEntity
{
    public required Guid    Id                      { get; set; }    //  Id оборудования
    public required string  SerialNumber            { get; set; }    //  серийный номер
    public required string  Name                    { get; set; }    //  название
    public required double  Frequency               { get; set; }    //  частота
    public required string  AttenuationCoefficient  { get; set; }    //  коэффициент затухания
    public required string  DTT                     { get; set; }    //  Data Transfer Technology (технология передачи данных)
    public required string  Address                 { get; set; }    //  расположение
}
