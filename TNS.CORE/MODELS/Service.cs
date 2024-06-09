using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace TNS.CORE.MODELS;

public class Service
{
    public Guid     Id   { get; }    //  id услуги
    public string   Name { get; }    //  имя услуги

    private Service(Guid id, string name) 
    {
        Id = id;
        Name = name;
    }

    public static Result<Service> Create(string name)
    {
        if (!IsValidServiceName(name)) return Result.Failure<Service>("ServiceName invalid");   //  валидация названия услуги

        Guid id = Guid.NewGuid();
        return Result.Success<Service>(new(id, name));
    }

    /// <summary>
    /// Валидация имени услуги
    /// </summary>
    /// <param name="name">Имя услуги</param>
    /// <returns>True - имя услуги корреткно</returns>
    private static bool IsValidServiceName(string name)
    {
        string[] existServiceName = [
            "Интернет",
            "Мобильная связь",
            "Телевидение",
            "Видеонаблюдение"
        ];
        try
        {
            if (string.IsNullOrEmpty(name))                             return false;   //  не null or empty
            if (!existServiceName.Contains(name))                       return false;   //  содержится в списке типов услуг
            if (!Regex.IsMatch(name, "^[a-zA-Zа-яА-Я0-9.,!?'\\s]+$"))   return false;   //  тип услуги состоит только из букв, цифр и пунктуации
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
