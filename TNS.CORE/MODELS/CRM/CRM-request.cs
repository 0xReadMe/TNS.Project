using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace TNS.CORE.MODELS.CRM;

public class CRM_request
{
    public Guid Id { get; }     //  id заявки
    public Guid SubscriberId { get; }     //  лицевой счет + номер абонента + тип оборудования
    public DateOnly CreationDate { get; }     //  дата создания
    public DateOnly ClosingDate { get; }     //  дата закрытия заявки
    public Guid ServiceId { get; }     //  услуга
    public Guid ServiceProvidedId { get; }     //  оказываемая услуга
    public Guid ServiceTypeId { get; }     //  тип услуги
    public string Status { get; }     //  статус услуги
    public string TypeOfProblem { get; }     //  тип проблемы
    public string ProblemDescription { get; }     //  описание услуги

    private CRM_request(Guid id,
                        Guid subscriberId,
                        DateOnly creationDate,
                        Guid serviceId,
                        Guid serviceProvidedId,
                        Guid serviceTypeId,
                        string status,
                        string typeOfProblem,
                        string problemDescription,
                        DateOnly closingDate)
    {
        Id = id;
        SubscriberId = subscriberId;
        CreationDate = creationDate;
        ServiceId = serviceId;
        ServiceProvidedId = serviceProvidedId;
        ServiceTypeId = serviceTypeId;
        Status = status;
        TypeOfProblem = typeOfProblem;
        ProblemDescription = problemDescription;
        ClosingDate = closingDate;
    }

    public static Result<CRM_request> Create(Guid subscriberId,
                                             DateOnly creationDate,
                                             Guid serviceId,
                                             Guid serviceProvidedId,
                                             Guid serviceTypeId,
                                             string status,
                                             string typeOfProblem,
                                             string problemDescription,
                                             DateOnly closingDate)
    {
        if (!IsValidCreationDate(creationDate)) return Result.Failure<CRM_request>("CreationDate invalid.");        //  валидация даты создания
        if (!IsValidClosingDate(closingDate, creationDate)) return Result.Failure<CRM_request>("ClosingDate invalid.");         //  валидация даты закрытия
        if (!IsValidStatus(status)) return Result.Failure<CRM_request>("Status invalid.");              //  валидация даты закрытия
        if (!IsValidTypeOfProblem(typeOfProblem)) return Result.Failure<CRM_request>("TypeOfProblem invalid.");       //  валидация типа проблемы
        if (!IsValidProblemDescription(problemDescription)) return Result.Failure<CRM_request>("ProblemDescription invalid.");  //  валидация описания проблемы

        Guid id = Guid.NewGuid();
        return Result.Success<CRM_request>(new(id,
                                               subscriberId,
                                               creationDate,
                                               serviceId,
                                               serviceProvidedId,
                                               serviceTypeId,
                                               status,
                                               typeOfProblem,
                                               problemDescription,
                                               closingDate));
    }

    /// <summary>
    /// Валидация описания проблемы
    /// </summary>
    /// <param name="problemDescription">Описание проблемы</param>
    /// <returns>True - описание проблемы корректно</returns>
    private static bool IsValidProblemDescription(string problemDescription)
    {
        string badWordsPattern = @"(?i)(мат|пизд|хуй|бля|нах[уиоь]|сука|еб[ао]т|говн|пид[аер]|хер|срал|ср[аи]т|залуп|муд[аое]к|ебал|ебик|ебл[ая]|ебун|залуп|мудач|пох[уие]р|пох[ие]й|спи[дж]|уеб[аиок]|хер[нягеа])";
        string pattern = @"^[\p{L}\p{N}\s,.!?@#$%^&*()_+\-=\[\]{};:""\\|,.<>\/?]*$";

        try
        {
            if (string.IsNullOrWhiteSpace(problemDescription)) return false;   // описание проблемы не пустое
            if (problemDescription.Length > 400) return false;   // длина описания проблемы не превышает 1000 символов
            if (!Regex.IsMatch(problemDescription, pattern)) return false;   // описание проблемы содержит только допустимые символы
            if (Regex.IsMatch(problemDescription, badWordsPattern)) return false;   // описание проблемы не содержит нецензурных русских выражений

            return true;
        }
        catch (Exception)
        {
            return false;                                                           // Возвращаем false, если возникла любая ошибка при проверке описания
        }
    }

    /// <summary>
    /// Валидация типа проблемы
    /// </summary>
    /// <param name="typeOfProblem">Тип проблемы</param>
    /// <returns>True - тип проблемы корректен</returns>
    private static bool IsValidTypeOfProblem(string typeOfProblem)
    {
        string[] existTypeOfProblem = [
            "Консультация",
            "Техническое обслуживание"
            ];
        try
        {
            if (string.IsNullOrEmpty(typeOfProblem)) return false;   //  не null or empty
            if (!existTypeOfProblem.Contains(typeOfProblem)) return false;   //  содержится в списке типов услуг
            if (!Regex.IsMatch(typeOfProblem, "^[a-zA-Zа-яА-Я0-9.,!?'\\s]+$")) return false;   //  тип услуги состоит только из букв, цифр и пунктуации
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Валидация статуса заявки
    /// </summary>
    /// <param name="status">Статус заявки</param>
    /// <returns>True - статус корректен</returns>
    private static bool IsValidStatus(string status)
    {
        string[] existStatus = [
            "Новая",
            "В работе",
            "Закрыта"
            ];
        try
        {
            if (string.IsNullOrEmpty(status)) return false;   //  не null or empty
            if (!existStatus.Contains(status)) return false;   //  содержится в списке типов услуг
            if (!Regex.IsMatch(status, "^[a-zA-Zа-яА-Я0-9.,!?'\\s]+$")) return false;   //  тип услуги состоит только из букв, цифр и пунктуации
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Валидация даты закрытия заявки
    /// </summary>
    /// <param name="closingDate">Дата закрытия заявки</param>
    /// <returns>True - Дата закрытия заявки корректна</returns>
    private static bool IsValidClosingDate(DateOnly closingDate, DateOnly creationDate)
    {
        try
        {
            
            if (closingDate < creationDate) return false;                           // не раньше даты создания заявки
            return true;
        }
        catch (Exception)
        {
            return false;                                                           // если возникла любая ошибка при проверке даты
        }
    }

    /// <summary>
    /// Валидация даты создания заявки
    /// </summary>
    /// <param name="creationDate">Дата создания заявки</param>
    /// <returns>True - дата создания заявки корректна</returns>
    private static bool IsValidCreationDate(DateOnly creationDate)
    {
        try
        {
            if (creationDate.Year < 1900) return false;   // не раньше 1900 года
            if (creationDate > DateOnly.FromDateTime(DateTime.Now).AddDays(1)) return false;   // не позже текущих суток
            return true;
        }
        catch (Exception)
        {
            return false;                                                                               // если возникла любая ошибка при проверке даты
        }
    }
}