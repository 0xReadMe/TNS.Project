using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace TNS.CORE.MODELS.CRM;

public class ServiceType
{
    public Guid Id { get; }    // id типа услуги
    public string Name { get; }    // название типа услуги

    private ServiceType(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Result<ServiceType> Create(string name)
    {
        if (!IsValidServiceTypeName(name)) return Result.Failure<ServiceType>("ServicTypeName invalid");

        Guid id = Guid.NewGuid();
        return Result.Success<ServiceType>(new(id, name));
    }

    /// <summary>
    /// Валидация названия типа услуги
    /// </summary>
    /// <param name="name">Тип услуги</param>
    /// <returns>True - тип услуги корректен</returns>
    private static bool IsValidServiceTypeName(string name)
    {
        string[] existServiceTypeNames = [
            "Подключение услуг с новой инфраструктурой",
            "Подключение услуг на существующей инфраструктуре",
            "Изменение условий договора",
            "Включение в договор дополнительной услуги",
            "Изменение контактных данных",
            "Изменение тарифа",
            "Изменение адреса предоставления услуг",
            "Отключение услуги",
            "Приостановка предоставления услуги",
            "Нет доступа к услуге",
            "Разрыв соединения",
            "Низкая скорость соединения",
            "Выписка по платежам",
            "Информация о платежах",
            "Получение квитанции на оплату услуги"
        ];
        try
        {
            if (string.IsNullOrEmpty(name)) return false;   //  не null or empty
            if (!existServiceTypeNames.Contains(name)) return false;   //  содержится в списке типов услуг
            if (!Regex.IsMatch(name, "^[a-zA-Zа-яА-Я0-9.,!?'\\s]+$")) return false;   //  тип услуги состоит только из букв, цифр и пунктуации
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
