namespace TNS.API.CONTRACTS.EQUIPMENT.EQUIPMENT
{
    public record TestEquipment_GET(
        string SerialNumber,           // серийный номер
        string Name,                   // название
        double Frequency,              // частота
        string AttenuationCoefficient, // коэффициент затухания
        string DTT,                    // Data Transfer Technology (технология передачи данных)
        string Address,                // расположение
        bool IsWorking                 // рабочее состояние
        );
}
