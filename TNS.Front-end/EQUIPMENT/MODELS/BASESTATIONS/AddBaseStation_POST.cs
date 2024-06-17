namespace TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS;

public record AddBaseStation_POST(
        Guid AddressId,
        string BaseStationName,         // название БС
        double S,                       // площадь зоны покрытия
        int Frequency,                  // частота, Гц
        string TypeAntenna,             // тип антенны
        int Handover,                   // показатель хендовера
        string CommunicationProtocol,   // стандарт связи
        bool IsWorking                  // рабочее состояние
    );

