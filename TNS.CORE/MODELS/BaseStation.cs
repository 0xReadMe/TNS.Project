using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace TNS.CORE.MODELS;

public class BaseStation
{
    public Guid     Id                      { get; }    //  id
    public Guid     AddressId               { get; }    //  id адреса станции
    public string   BaseStationName         { get; }    //  название БС
    public double   S                       { get; }    //  площадь зоны покрытия
    public int      Frequency               { get; }    //  частота, Гц
    public string   TypeAntenna             { get; }    //  тип антенны
    public int      Handover                { get; }    //  показатель хендовера
    public string   CommunicationProtocol   { get; }    //  стандарт связи


    private BaseStation(Guid    id,
                        Guid    adressId,
                        string  baseStationName,
                        double  S,
                        int     frequency,
                        string  typeAntenna,
                        int     handover,
                        string  communicationProtocol) 
    {
        Id                      = id;
        AddressId               = adressId;
        BaseStationName         = baseStationName;
        this.S                  = S; 
        Frequency               = frequency;
        TypeAntenna             = typeAntenna;
        Handover                = handover;
        CommunicationProtocol   = communicationProtocol;
    }

    public static Result<BaseStation> Create(Guid   adressId,
                                             string baseStationName,
                                             double S,
                                             int    frequency,
                                             string typeAntenna,
                                             int    handover,
                                             string communicationProtocol) 
    {
        if (!IsValidBaseStationName(baseStationName))               return Result.Failure<BaseStation>("BaseStationName invalid");          //  валидация названия БС
        if (!IsValidS(S))                                           return Result.Failure<BaseStation>("S invalid");                        //  валидация площади зоны покрытия
        if (!IsValidFrequency(frequency))                           return Result.Failure<BaseStation>("Frequency invalid");                //  валидация частоты, Гц
        if (!IsValidTypeAntenna(typeAntenna))                       return Result.Failure<BaseStation>("TypeAntenna invalid");              //  валидация типа антенны
        if (!IsValidHandover(handover))                             return Result.Failure<BaseStation>("Handover invalid");                 //  валидация показателя хендовера
        if (!IsValidCommunictationProtocol(communicationProtocol))  return Result.Failure<BaseStation>("CommunictationProtocol invalid");   //  валидация стандарта связи

        Guid id = Guid.NewGuid();
        return Result.Success<BaseStation>(new(id, adressId, baseStationName, S, frequency, typeAntenna, handover, communicationProtocol));
    }

    /// <summary>
    /// Валидация стандарта связи
    /// </summary>
    /// <param name="communictationProtocol">Стандарт связи</param>
    /// <returns>True - стандарт связи корректен</returns>
    private static bool IsValidCommunictationProtocol(string communicationProtocol)
    {
        string pattern = @"^[\p{L}\p{N}\s\-_]+$";
        string[] validProtocols =
        [
            "TCP/IP",
            "UDP",
            "ICMP",
            "SNMP",
            "HTTP",
            "HTTPS",
            "FTP",
            "SFTP",
            "TELNET",
            "SSH",
            "SIP",
            "RTP",
            "RTSP"
        ];

        try
        {
            
            if (string.IsNullOrWhiteSpace(communicationProtocol))                               return false;   // не пустой
            if (communicationProtocol.Length > 50)                                              return false;   // длина не превышает 50 символов
            if (!System.Text.RegularExpressions.Regex.IsMatch(communicationProtocol, pattern))  return false;   // содержит только допустимые символы (буквы, цифры, пробелы, дефисы, подчеркивания)
            if (!validProtocols.Contains(communicationProtocol))                                return false;   // соответствует одному из известных стандартов для телекоммуникационной компании
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                       // Возвращаем false, если возникла любая ошибка при проверке коммуникационного протокола
        }
    }

    /// <summary>
    /// Валидация показателя хендовера
    /// </summary>
    /// <param name="handover">Показатель хендовера</param>
    /// <returns>True - показатель хендовера корректен</returns>
    private static bool IsValidHandover(int handover)
    {
        try
        {
            if (handover < 1 || handover > 100) return false;   // хендовер находится в допустимом диапазоне
            return true;
        }
        catch (Exception)
        {
            return false;                                       // Возвращаем false, если возникла любая ошибка при проверке хендовера
        }
    }

    /// <summary>
    /// Валидация типа антенны
    /// </summary>
    /// <param name="typeAntenna">Тип антенны</param>
    /// <returns>True - тип антенны корректен</returns>
    private static bool IsValidTypeAntenna(string typeAntenna)
    {
        string pattern = @"^[\p{L}\p{N}\s\-_]+$";
        string[] validTypes =
        [
            "Всенаправленная",
            "Направленная",
            "Параболическая",
            "Яги",
            "Патч",
            "Дипольная",
            "Бинаправленная",
            "Логопериодическая"
        ];

        try
        {
            if (string.IsNullOrWhiteSpace(typeAntenna))                                 return false;   // не пустой
            if (typeAntenna.Length > 30)                                                return false;   // длина не превышает 30 символов
            if (!System.Text.RegularExpressions.Regex.IsMatch(typeAntenna, pattern))    return false;   // содержит только допустимые символы (буквы, цифры, пробелы, дефисы, подчеркивания)
            if (!validTypes.Contains(typeAntenna))                                      return false;   // соответствует одному из известных типов
            return true;
        }
        catch (Exception)
        {
            return false;                                                                               // Возвращаем false, если возникла любая ошибка при проверке типа антенны
        }
    }

    /// <summary>
    /// Валидация частоты
    /// </summary>
    /// <param name="frequency">Частота</param>
    /// <returns>True - частота корректна</returns>
    private static bool IsValidFrequency(int frequency)
    {
        try
        {
            if (frequency < 100 || frequency > 6000)                                return false;   // находится в допустимом диапазоне
            if (frequency % 100 != 0)                                               return false;   // является кратной 100 Гц
            if (frequency >= 100 && frequency <= 1000 && frequency % 100 != 0)      return false;   // если частота находится в диапазоне 100-1000 Гц, то она должна быть кратной 100 Гц
            if (frequency >= 1001 && frequency <= 3000 && frequency % 500 != 0)     return false;   // если частота находится в диапазоне 1001-3000 Гц, то она должна быть кратной 500 Гц
            if (frequency >= 3001 && frequency <= 6000 && frequency % 1000 != 0)    return false;   // если частота находится в диапазоне 3001-6000 Гц, то она должна быть кратной 1000 Гц
            return true;
        }
        catch (Exception)
        {
            return false;                                                                           // возвращаем false, если возникла любая ошибка при проверке частоты
        }
    }

    /// <summary>
    /// Валидация площади зоны покрытия
    /// </summary>
    /// <param name="s">Площади зоны покрытия</param>
    /// <returns>True - зона покрытия корректна</returns>
    private static bool IsValidS(double s)
    {
        try
        {
            if (s < 1.0 || s > 3000.0)      return false;   // площадь находится в допустимом диапазоне
            if (Math.Round(s * 2) % 2 != 0) return false;   // площадь является кратной 0.5 кв.м
            return true;
        }
        catch (Exception)
        {
            return false;                                   // Возвращаем false, если возникла любая ошибка при проверке площади
        }
    }

    /// <summary>
    /// Валидация названия БС
    /// </summary>
    /// <param name="baseStationName">Название БС</param>
    /// <returns>True - название БС корректно</returns>
    private static bool IsValidBaseStationName(string baseStationName)
    {
        string pattern = @"^[\p{IsCyrillic}\p{N}\s\-_]+$";
        try
        {
            if (string.IsNullOrWhiteSpace(baseStationName)) return false;   // название станции не пустое
            if (baseStationName.Length > 100)               return false;   // длина названия станции не превышает 100 символов
            if (!Regex.IsMatch(baseStationName, pattern))   return false;   // название станции содержит только допустимые символы (буквы кириллицы, цифры, пробелы, дефисы, подчеркивания)
            return true;
        }
        catch (Exception)
        {
            return false;                                                   // Возвращаем false, если возникла любая ошибка при проверке названия станции
        }
    }
}