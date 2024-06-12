using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace TNS.CORE.MODELS.EMPLOYEE;

public class Event
{
    public Guid Id { get; }    //  id события
    public Guid PositionId { get; }    //  id должности
    public DateOnly Date { get; }    //  дата события
    public string Description { get; }    //  описание события
    public TimeOnly Time { get; }    //  время события

    private Event(Guid id,
                  Guid positionId,
                  DateOnly eventDate,
                  string eventDescription,
                  TimeOnly eventTime)
    {
        Id = id;
        PositionId = positionId;
        Date = eventDate;
        Description = eventDescription;
        Time = eventTime;
    }

    public static Result<Event> Create(Guid positionId,
                                       DateOnly eventDate,
                                       string? eventDescription,
                                       TimeOnly? eventTime)
    {
        eventDescription ??= "Описание отсутствует";
        TimeOnly eventTimeNotNull = eventTime ?? new TimeOnly(0, 0, 0);
        if (!IsValidEventDate(eventDate)) return Result.Failure<Event>("Event Date invalid");         //  валидация даты события
        if (!IsValidEventDescription(eventDescription)) return Result.Failure<Event>("Event Description invalid");  //  валидация описания события
        if (!IsValidEventTime(eventTime)) return Result.Failure<Event>("EventTime invalid");          //  валидация времени события

        Guid id = Guid.NewGuid();
        return Result.Success<Event>(new(id, positionId, eventDate, eventDescription, eventTimeNotNull));
    }

    /// <summary>
    /// Валидация времени события
    /// </summary>
    /// <param name="eventTime">Время события</param>
    /// <returns>True - время события корректно</returns>
    private static bool IsValidEventTime(TimeOnly? eventTime)
    {
        try
        {
            if (!eventTime.HasValue) return false;                                                          //  время события не равно null
            if (eventTime.Value < TimeOnly.MinValue || eventTime.Value > TimeOnly.MaxValue) return false;   //  время события находится в допустимом диапазоне
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                   // Возвращаем false, если возникла любая ошибка при проверке времени
        }
    }

    /// <summary>
    /// Валидация описания события
    /// </summary>
    /// <param name="eventDescription">Описание события</param>
    /// <returns>True - описание события корректное</returns>
    private static bool IsValidEventDescription(string? eventDescription)
    {
        try
        {
            if (string.IsNullOrEmpty(eventDescription)) return false;   // описание события не равно null
            if (eventDescription.Length > 25) return false;   // длина описания события не превышает 500 символов
            if (!Regex.IsMatch(eventDescription, @"^[\p{L}\p{N}\s,.!?']+$")) return false;   // описание события содержит только допустимые символы (буквы, цифры, пробелы, знаки препинания)
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                                   // Возвращаем false, если возникла любая ошибка при проверке описания
        }
    }

    /// <summary>
    /// Валидация даты события
    /// </summary>
    /// <param name="eventDate">Дата события</param>
    /// <returns>True - дата события валидна</returns>
    private static bool IsValidEventDate(DateOnly eventDate)
    {
        try
        {
            if (eventDate < DateOnly.FromDateTime(DateTime.Now)) return false;   //  дата события не раньше текущей даты
            if (eventDate.Year > DateOnly.FromDateTime(DateTime.Now).AddYears(5).Year) return false;   //  дата события не позже текущего года + 5 лет
            return true;
        }
        catch (Exception)
        {
            return false;                                                                               // Возвращаем false, если возникла любая ошибка при проверке даты
        }
    }
}