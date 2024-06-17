namespace TNS.Front_end.EQUIPMENT.MODELS.BASESTATIONS
{
    public record TestBaseStations_GET(
        string BaseStationName,         // название БС
        double S,                       // площадь зоны покрытия
        int Frequency,                  // частота, Гц
        string TypeAntenna,             // тип антенны
        int Handover,                   // показатель хендовера
        string CommunicationProtocol,   // стандарт связи
        bool IsWorking                  // рабочее состояние
        );
}
