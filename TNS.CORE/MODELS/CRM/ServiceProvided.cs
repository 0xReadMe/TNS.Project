using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace TNS.CORE.MODELS.CRM;

public class ServiceProvided
{
    public Guid Id { get; }    //  id оказываемой услуги
    public string Name { get; }    //  оказываемая услуга

    private ServiceProvided(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Result<ServiceProvided> Create(string name)
    {
        if (!IsValidServiceProvidedName(name)) return Result.Failure<ServiceProvided>("ServiceProvided invalid");    //  валидация названия оказываемой услуги

        Guid id = Guid.NewGuid();
        return Result.Success<ServiceProvided>(new(id, name));
    }

    /// <summary>
    /// Валидация оказываемой услуги
    /// </summary>
    /// <param name="name">Оказываемая услуга</param>
    /// <returns>True - оказываемая услуга корректна</returns>
    private static bool IsValidServiceProvidedName(string name)
    {
        string[] existServiceProvidedName = [
            "Подключение",
            "Управление договором/контактными данными",
            "Управление тарифом/услугой",
            "Диагностика и настройка оборудования/подключения",
            "Оплата услуг"
        ];
        try
        {
            if (string.IsNullOrEmpty(name)) return false;   //  не null or empty
            if (!existServiceProvidedName.Contains(name)) return false;   //  содержится в списке типов услуг
            if (!Regex.IsMatch(name, "^[a-zA-Zа-яА-Я0-9.,!?'\\s]+$")) return false;   //  тип услуги состоит только из букв, цифр и пунктуации
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
