using CSharpFunctionalExtensions;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TNS.CORE.MODELS.SUBSCRIBER;

public partial class Subscriber
{
    public Guid     Id                              { get; }        //  id абонента
    public Guid     PersonId                        { get; set; }   //  id человека
    public string   SubscriberNumber                { get; }        //  номер абонента
    public string   ContractNumber                  { get; }        //  номер договора
    public bool     ContractType                    { get; }        //  тип договора (true - с пролонгацией, false - без пролонгации)
    public string   ReasonForTerminationOfContract  { get; }        //  причина расторжения договора
    public uint     PersonalBill                    { get; }        //  лицевой счет
    public string   Services                        { get; }        //  услуги
    public DateOnly DateOfContractConclusion        { get; }        //  дата заключения договора
    public DateOnly DateOfTerminationOfTheContract  { get; }        //  дата расторжения договора
    public string   TypeOfEquipment                 { get; }        //  тип оборудования

    private Subscriber(Guid id,
                       DateOnly dateOfContractConclusion,
                       DateOnly dateOfTerminationOfTheContract,
                       string subscriberNumber,
                       string contractNumber,
                       string reasonForTerminationOfContract,
                       string typeOfEquipment,
                       string services,
                       bool contractType,
                       uint personalBill)
    {
        Id = id;
        SubscriberNumber = subscriberNumber;
        ContractNumber = contractNumber;
        DateOfContractConclusion = dateOfContractConclusion;
        ContractType = contractType;
        ReasonForTerminationOfContract = reasonForTerminationOfContract;
        PersonalBill = personalBill;
        Services = services;
        DateOfTerminationOfTheContract = dateOfTerminationOfTheContract;
        TypeOfEquipment = typeOfEquipment;
    }


    public static Result<Subscriber> Create(DateOnly dateOfContractConclusion,
                                            DateOnly dateOfTerminationOfTheContract,
                                            string? reasonForTerminationOfContract,
                                            string typeOfEquipment,
                                            string services,
                                            bool contractType,
                                            uint personalBill)
    {
        reasonForTerminationOfContract ??= "Не указана";
        if (!IsValidReasonForTerminationOfContract(reasonForTerminationOfContract)) return Result.Failure<Subscriber>("Reason for termination contract invalid.");
        if (!IsValidDateOfContractConclusion(dateOfContractConclusion)) return Result.Failure<Subscriber>("Date Of Contract Conclusion invalid.");
        if (!IsValidDateOfTerminationOfTheContract(dateOfTerminationOfTheContract, dateOfContractConclusion)) return Result.Failure<Subscriber>("Date Of Termination Of TheContract invalid.");
        if (!IsValidTypeOfEquipment(typeOfEquipment)) return Result.Failure<Subscriber>("TypeOfEquipment invalid.");
        if (!IsValidServices(services)) return Result.Failure<Subscriber>("Services invalid.");
        if (!IsValidPersonalBill(personalBill)) return Result.Failure<Subscriber>("Personal Bill invalid.");
        Guid id = Guid.NewGuid();
        string subscriberNumber = GenerateSubscriberNumber(personalBill);
        string contractNumber = GenerateContractNumber(subscriberNumber, dateOfContractConclusion.Month, dateOfContractConclusion.Year);

        return Result.Success<Subscriber>(new(id, dateOfContractConclusion, dateOfTerminationOfTheContract, subscriberNumber, contractNumber,
                                              reasonForTerminationOfContract, typeOfEquipment, services, contractType, personalBill));
    }

    /// <summary>
    /// Добавление айди человека к существующему абоненту
    /// </summary>
    /// <param name="sub">Сущность абонента</param>
    /// <param name="personId">Айди существующего человека</param>
    /// <returns>Сущность абонента с добавленным айди существующего человека</returns>
    public static Result<Subscriber> AddPersonId(Subscriber sub, Guid personId)
    {
        sub.PersonId = personId;
        return Result.Success(sub);
    }

    private static bool IsValidPersonalBill(uint personalBill) => Regex.IsMatch(personalBill.ToString(), @"^\d{9}$");

    /// <summary>
    /// Валидация услуги
    /// </summary>
    /// <param name="service">Услуга</param>
    /// <returns>True - услуга корректна</returns>
    private static bool IsValidServices(string service)
    {
        string[] servicesExist = [
            "Интернет",
            "Мобильная связь",
            "Телевидение",
            "Видеонаблюдение"];
        try
        {
            if (string.IsNullOrEmpty(service)) return false;   //  услуга не пустая
            if (!servicesExist.Contains(service)) return false;   //  услуга есть в списке
            return true;
        }
        catch (Exception)
        {
            return false;                                           //  Возвращаем false, если возникла любая ошибка при проверке причины
        }
    }

    /// <summary>
    /// Валидация типа оборудования
    /// </summary>
    /// <param name="typeOfEquipment">Тип оборудования</param>
    /// <returns>True - тип оборудования корректен</returns>
    private static bool IsValidTypeOfEquipment(string typeOfEquipment)
    {
        string[] existEquipmentTypes =
        [
            "Маршрутизатор",
            "Коммутатор",
            "Точка доступа",
            "Сервер",
            "Шлюз",
            "Модем",
            "Концентратор",
            "Принтер",
            "Телефон",
            "Ноутбук",
            "Планшет"
        ];
        string pattern = @"^[\p{IsCyrillic}\p{N}\s\-_]+$";
        try
        {

            if (string.IsNullOrWhiteSpace(typeOfEquipment)) return false;   //  не пустой
            if (typeOfEquipment.Length > 50) return false;   //  не превышает 50 символов
            if (!Regex.IsMatch(typeOfEquipment, pattern)) return false;   //  содержит только допустимые символы (буквы кириллицы, цифры, пробелы, дефисы, подчеркивания)
            if (!existEquipmentTypes.Contains(typeOfEquipment)) return false;   //  является одним из существующих типов
            return true;
        }
        catch (Exception)
        {
            return false;                                                       // Возвращаем false, если возникла любая ошибка при проверке типа оборудования
        }
    }

    /// <summary>
    /// Валидация даты расторжения договора
    /// </summary>
    /// <param name="dateOfTerminationOfTheContract">Дата расторжения договора</param>
    /// <param name="dateOfContractConclusion">Дата заключения договора</param>
    /// <returns>True - дата корректна</returns>
    private static bool IsValidDateOfTerminationOfTheContract(DateOnly dateOfTerminationOfTheContract, DateOnly dateOfContractConclusion)
    {
        try
        {
            if (dateOfTerminationOfTheContract < dateOfContractConclusion) return false;       // не раньше даты заключения договора
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                               // если возникла любая ошибка при проверке даты
        }
    }

    /// <summary>
    /// Валидация даты заключения договора
    /// </summary>
    /// <param name="dateOfContractConclusion">Дата заключения договора</param>
    /// <returns>True - дата заключения договора корректная.</returns>
    private static bool IsValidDateOfContractConclusion(DateOnly dateOfContractConclusion)
    {
        try
        {
            if (dateOfContractConclusion > DateOnly.FromDateTime(DateTime.Now)) return false;   // не в будущем
            if (dateOfContractConclusion.Year < 1900) return false;   // не раньше 1900 года
            if (dateOfContractConclusion.Year > DateOnly.FromDateTime(DateTime.Now).AddYears(5).Year) return false;   // не позже текущего года + 5 лет
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                               // если возникла любая ошибка при проверке даты
        }
    }

    /// <summary>
    /// Валидация причины расторжения договора
    /// </summary>
    /// <param name="reasonForTerminationOfContract">Причина расторжения договора</param>
    /// <returns>True - причина корректная.</returns>
    private static bool IsValidReasonForTerminationOfContract(string reasonForTerminationOfContract)
    {
        string[] validReasons = [
            "Истечение срока договора",
            "Нарушение условий договора",
            "Смена места жительства",
            "Финансовые трудности",
            "Не указана"];

        try
        {
            if (string.IsNullOrWhiteSpace(reasonForTerminationOfContract)) return false;               // причина расторжения договора не пустая
            if (reasonForTerminationOfContract.Length > 200) return false;               // длина причины не превышает 200 символов
            if (!Regex.IsMatch(reasonForTerminationOfContract, "^[a-zA-Zа-яА-Я0-9.,!?'\\s]+$")) return false;               // причина состоит только из букв, цифр и пунктуации
            if (!validReasons.Contains(reasonForTerminationOfContract)) return false;               // причина соответствует списку допустимых причин расторжения (например)
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                                   // Возвращаем false, если возникла любая ошибка при проверке причины
        }
    }

    /// <summary>
    /// Генерация номера абонента
    /// </summary>
    /// <returns>Номер абонента</returns>
    private static string GenerateSubscriberNumber(uint personalBill)
    {
        //50-personalBill-KOLOMNA
        return $"50-{personalBill.ToString().PadLeft(9, '0')}-KOLOMNA";     // возвращаем полный номер абонента
    }

    /// <summary>
    /// Генерация номера договора абонента
    /// </summary>
    /// <param name="subscriberNumber">Номер абонента</param>
    /// <param name="month">Месяц</param>
    /// <param name="year">Год</param>
    /// <returns>Номер договора</returns>
    private static string GenerateContractNumber(string subscriberNumber, int month, int year)
    {
        //50-12345-KOLOMNA-месяц-год
        if (string.IsNullOrWhiteSpace(subscriberNumber) || month < 1 || month > 12 || year < 1900 || year > 2100) return "50-12345-KOLOMNA-ошибка-ошибка";  // Проверяем корректность входных данных
        return $"{subscriberNumber}-{month:D2}-{year:D4}";
    }
}