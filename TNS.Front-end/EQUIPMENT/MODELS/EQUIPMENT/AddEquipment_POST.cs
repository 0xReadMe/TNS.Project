﻿namespace TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;

public record AddEquipment_POST(
        string SerialNumber,           // серийный номер
        string Name,                   // название
        double Frequency,              // частота
        string AttenuationCoefficient, // коэффициент затухания
        string DTT,                    // Data Transfer Technology (технология передачи данных)
        string Address,                // расположение
        bool IsWorking               // рабочее состояние
    );
