using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS;

public class EmployeePosition 
{
    private readonly List<Employee> _employees = [];                        //  одна роль - множество сотрудников

    public Guid     Id              { get; }                                //  id должности
    public string   PositionName    { get; }                                //  название должности

    public IReadOnlyList<Employee>? Employees => _employees;

    private EmployeePosition(Guid   id, string positionName) 
    {
        Id              = id;
        PositionName    = positionName;
    }

    public static Result<EmployeePosition> Create(Guid id, string positionName)
    {
        if (!IsValidPositionName(positionName)) return Result.Failure<EmployeePosition>("PositionName invalid.");   //  валидация должности
        return Result.Success<EmployeePosition>(new(id, positionName));
    }

    /// <summary>
    /// Валидация названия должности
    /// </summary>
    /// <param name="positionName">Название должности</param>
    /// <returns>True - должность корректна.</returns>
    private static bool IsValidPositionName(string positionName) 
    {
        string[] existPositionName = ["Начальник отдела", "Системный администратор", "Инженер связи", "Специалист технической поддержки"];
        try
        {
            if (string.IsNullOrWhiteSpace(positionName))                                                return false;   //  должность не пустая
            if (positionName.Length > 30)                                                               return false;   //  длина должности не превышает максимально допустиму
            if (!System.Text.RegularExpressions.Regex.IsMatch(positionName, "^[a-zA-Zа-яА-Я0-9\\s]+$")) return false;   //  должность состоит только из букв, цифр и пробелов
            if (!existPositionName.Contains(positionName))                                              return false;   //  должность соответствует списку допустимых должностей

            return true;
        }
        catch (Exception)
        {
            return false;                                                                                               //  возвращаем false, если возникла любая ошибка при проверке должности
        }
    }
}