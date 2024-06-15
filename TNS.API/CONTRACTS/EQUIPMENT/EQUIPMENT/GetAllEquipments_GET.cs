namespace TNS.API.CONTRACTS.EQUIPMENT.EQUIPMENT
{
    public record GetAllEquipments_GET(
        Guid id,
        string SerialNumber,           // серийный номер
        string Name,                   // название
        double Frequency,              // частота
        string AttenuationCoefficient, // коэффициент затухания
        string DTT,                    // Data Transfer Technology (технология передачи данных)
        string Address,                // расположение
        bool IsWorking               // рабочее состояние
        );
}
