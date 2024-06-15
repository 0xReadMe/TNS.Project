namespace TNS.API.CONTRACTS.EQUIPMENT.BASESTATIONS;

public record EditBaseStation_PUT(
    Guid AddressId,
    string BaseStationName,         // название БС
    double S,                       // площадь зоны покрытия
    int Frequency,                  // частота, Гц
    string TypeAntenna,             // тип антенны
    int Handover,                   // показатель хендовера
    string CommunicationProtocol,   // стандарт связи
    bool IsWorking                  // рабочее состояние
);
