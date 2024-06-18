using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace TNS.CORE.MODELS.EQUIPMENT;

public class Equipment
{
    public Guid Id { get; }    //  Id оборудования
    public string SerialNumber { get; }    //  серийный номер
    public string Name { get; }    //  название
    public double Frequency { get; }    //  частота
    public string AttenuationCoefficient { get; }    //  коэффициент затухания
    public string DTT { get; }    //  Data Transfer Technology (технология передачи данных)
    public string Address { get; }    //  расположение
    public bool IsWorking { get; set; }

    public Equipment(Guid id,
                     string serialNumber,
                     string name,
                     double frequency,
                     string attenuationCoefficient,
                     string DTT,
                     string address,
                     bool isWorking)
    {
        Id = id;
        SerialNumber = serialNumber;
        Name = name;
        Frequency = frequency;
        AttenuationCoefficient = attenuationCoefficient;
        this.DTT = DTT;
        Address = address;
        IsWorking = isWorking;
    }

    public static Result<Equipment> Create(string serialNumber,
                                           string name,
                                           double frequency,
                                           string attenuationCoefficient,
                                           string DTT,
                                           string address,
                                           bool isWorking)
    {
        if (!IsValidSerialNumber(serialNumber)) return Result.Failure<Equipment>("Equipment SerialNumber invalid");             //  валидация серийного номера
        if (!IsValidName(name)) return Result.Failure<Equipment>("Equipment Name invalid");                     //  валидация названия оборудования
        if (!IsValidDTT(DTT)) return Result.Failure<Equipment>("Equipment Data Transfer Technology invalid"); //  валидация дтт
        if (!IsValidAddress(address)) return Result.Failure<Equipment>("Equipment Address invalid");                  //  валидация адреса

        Guid id = Guid.NewGuid();
        return Result.Success<Equipment>(new(id, serialNumber, name, frequency, attenuationCoefficient, DTT, address, isWorking));
    }

    /// <summary>
    /// Валидация адреса оборудования
    /// </summary>
    /// <param name="address">Адрес (абонента, магистрального оборудования, сетевого оборудования)</param>
    /// <returns>True - адрес корректен</returns>
    private static bool IsValidAddress(string address)
    {
        string[] parts = address.Split(',');
        string pattern = @"^[\p{L}\p{N}\s\.\:\-\,]+$";
        try
        {
            if (string.IsNullOrWhiteSpace(address)) return false;                // адрес не пустой
            if (address.Length > 100) return false;                // длина адреса не превышает 100 символов
            if (!Regex.IsMatch(address, pattern)) return false;                // адрес содержит только допустимые символы (буквы, цифры, пробелы, точки, двоеточия, дефисы, запятые)
            if (!address.Contains(",")) return false;                // адрес содержит как минимум одну запятую
            if (parts.Length > 5) return false;                // адрес содержит не более 5 частей, разделенных запятыми

            // Проверяем, что каждая часть адреса не пустая и не превышает 30 символов
            foreach (string part in parts)
            {
                if (string.IsNullOrWhiteSpace(part) || part.Length > 30) return false;
            }

            return true;
        }
        catch (Exception)
        {
            return false;                                                        // Возвращаем false, если возникла любая ошибка при проверке адреса
        }
    }

    /// <summary>
    /// Валидация DTT (Data Transfer Technology)
    /// </summary>
    /// <param name="DTT">Data Transfer Technology</param>
    /// <returns>True - Data Transfer Technology корректен</returns>
    private static bool IsValidDTT(string DTT)
    {
        string pattern = @"^[\p{L}\p{N}\s\-_]+$";
        string[] validDTTs =
        [
            "Ethernet",
            "Wi-Fi",
            "Bluetooth",
            "USB",
            "Optical Fiber",
            "SHDSL",
            "ADSL",
            "VDSL",
            "G.Fast",
            "LTE",
            "5G"
        ];
        try
        {
            if (string.IsNullOrWhiteSpace(DTT)) return false;                // DTT не пустой
            if (DTT.Length > 50) return false;                // длина DTT не превышает 50 символов
            if (!Regex.IsMatch(DTT, pattern)) return false;                // DTT содержит только допустимые символы (буквы, цифры, пробелы, дефисы, подчеркивания)
            if (!validDTTs.Contains(DTT)) return false;                // DTT соответствует одной из известных технологий для телекоммуникационной компании
            return true;
        }
        catch (Exception)
        {
            return false;                                                    // Возвращаем false, если возникла любая ошибка при проверке DTT
        }
    }
       
    /// <summary>
    /// Валидация названия оборудования
    /// </summary>
    /// <param name="name">Название оборудования</param>
    /// <returns>True - название корректно</returns>
    private static bool IsValidName(string name)
    {
        string pattern = @"^[\p{L}\p{N}\s\-\.]+$";
        try
        {
            if (string.IsNullOrWhiteSpace(name)) return false;   // название оборудования не пустое
            if (name.Length > 100) return false;   // длина названия оборудования не превышает 100 символов
            if (!Regex.IsMatch(name, pattern)) return false;   // название оборудования содержит только допустимые символы (буквы, цифры, пробелы, дефисы, точки)
            return true;
        }
        catch (Exception)
        {
            return false;                                           // Возвращаем false, если возникла любая ошибка при проверке названия
        }
    }

    /// <summary>
    /// Валидация серийного номера оборудования 
    /// </summary>
    /// <param name="serialNumber">Серийный номер</param>
    /// <returns>True - серийный номер корректен</returns>
    private static bool IsValidSerialNumber(string serialNumber)
    {
        //АО567-ТНС-11
        if (string.IsNullOrEmpty(serialNumber)) return false;                    // Проверка на null или пустую строку
        return Regex.IsMatch(serialNumber, @"^[А-Я]{2}\d{3}-[А-Я]{3}-\d{2}$");   // Проверка совпадения серийного номера с шаблоном
    }
}