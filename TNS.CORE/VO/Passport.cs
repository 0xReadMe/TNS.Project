using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace TNS.CORE.VO;

public partial class Passport : ValueObject
{
    public string DivisionCode { get; }
    public string IssuedBy { get; }
    public int Series  { get; }
    public int Number { get; }
    public string ResidenceAddress { get; }
    public string ResidentialAddress { get; }
    public DateOnly DateOfIssueOfPassport { get; }

    private Passport(string divisionCode, string issuedBy, int series, int number, string residenceAddress, string residentialAddress, DateOnly dateOfIssueOfPassport) 
    {
        DivisionCode = divisionCode;
        IssuedBy = issuedBy;
        Series = series;
        Number = number;
        ResidenceAddress = residenceAddress;
        ResidentialAddress = residentialAddress;
        DateOfIssueOfPassport = dateOfIssueOfPassport;
    }

    public static Result<Passport> Create(string divisionCode, string issuedBy, int series, int number, string residenceAddress, string residentialAddress, DateOnly dateOfIssueOfPassport) 
    {
        if (!IsValidDateOfIssueOfPassport(dateOfIssueOfPassport))   return Result.Failure<Passport>("Date Of Issue Of Passport invalid");       //  валидация даты выдачи
        if (!IsValidDivisionCode(divisionCode))                     return Result.Failure<Passport>("divisionCode Passport invalid");           //  валидация кода подразделения
        if (!IsValidIssuedBy(issuedBy))                             return Result.Failure<Passport>("issuedBy invalid");                        //  валидация "кем выдано"
        if (!IsValidNumber(number.ToString()))                      return Result.Failure<Passport>("number Of Passport invalid");              //  валидация номера паспорта
        if (!IsValidSeries(series.ToString()))                      return Result.Failure<Passport>("series Of Passport invalid");              //  валидация серии паспорта
        if (!IsValidResidenceAddress(residenceAddress))             return Result.Failure<Passport>("residenceAddress Of Passport invalid");    //  валидация прописки
        if (!IsValidResidenceAddress(residentialAddress))           return Result.Failure<Passport>("residentialAddress Of Passport invalid");  //  валидация места рождения
        return Result.Success<Passport>(new(divisionCode, issuedBy, series, number, residenceAddress, residentialAddress, dateOfIssueOfPassport));
    }

    const string regexDivisionCode = @"^\d{3}\-\d{3}$";
    const string regexSeries = @"(^\d{4}$)";
    const string regexNumber = @"(^\d{6}$)";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="issuedBy"></param>
    /// <returns></returns>
    static bool IsValidIssuedBy(string issuedBy)
    {
        string pattern = @"^[\p{L}\p{N}\s\-_,]+$";
        try
        {
            if (string.IsNullOrWhiteSpace(issuedBy))    return false;   // не пустое
            if (issuedBy.Length > 100)                  return false;   // имеет длину не более 100 символов
            if (!Regex.IsMatch(issuedBy, pattern))      return false;   // содержит только допустимые символы (буквы, цифры, пробелы, дефисы, подчеркивания, запятые)
            return true;
        }
        catch (Exception)
        {
            return false;                                               // Возвращаем false, если возникла любая ошибка при проверке "кем выдано"
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisionCode"></param>
    /// <returns></returns>
    static bool IsValidDivisionCode(string divisionCode) 
    {
        string pattern = @"^[\d\-]+$";
        try
        {
            
            if (string.IsNullOrWhiteSpace(divisionCode))                                            return false;   // код подразделения не пустой
            if (divisionCode.Length > 10)                                                           return false;   // код подразделения имеет длину не более 10 символов
            if (!Regex.IsMatch(divisionCode, pattern) || !RegDivCode().Match(divisionCode).Success) return false;   // код подразделения содержит только цифры и дефисы
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                           // Возвращаем false, если возникла любая ошибка при проверке кода подразделения
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="series"></param>
    /// <returns></returns>
    static bool IsValidSeries(string series)
    {
        string pattern = @"^\d+$";
        try
        {
            if (string.IsNullOrWhiteSpace(series))                                                  return false;   // серия паспорта не пустая
            if (series.Length != 4)                                                                 return false;   // серия паспорта имеет длину 4 символа
            if (!Regex.IsMatch(series, pattern) || !RegSeries().Match(series.ToString()).Success)   return false;   // серия паспорта содержит только цифры
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                           // Возвращаем false, если возникла любая ошибка при проверке серии паспорта
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    static bool IsValidNumber(string number)
    {
        string pattern = @"^\d+$";
        try
        {
            if (string.IsNullOrWhiteSpace(number))                                                  return false;   // номер паспорта не пустой
            if (number.Length != 6)                                                                 return false;   // номер паспорта имеет длину 6 символов
            if (!Regex.IsMatch(number, pattern) || !RegNumber().Match(number.ToString()).Success)   return false;   // номер паспорта содержит только цифры
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                           // Возвращаем false, если возникла любая ошибка при проверке номера паспорта
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="residenceAddress"></param>
    /// <returns></returns>
    static bool IsValidResidenceAddress(string residenceAddress)
    {
        string pattern = @"^[\p{L}\p{N}\s\-_,\.]+$";
        try
        {
            if (string.IsNullOrWhiteSpace(residenceAddress))    return false;   // адрес регистрации не пустой
            if (residenceAddress.Length > 200)                  return false;   // адрес регистрации имеет длину не более 200 символов
            if (!Regex.IsMatch(residenceAddress, pattern))      return false;   // адрес регистрации содержит только допустимые символы (буквы, цифры, пробелы, дефисы, подчеркивания, запятые, точки)
            return true;
        }
        catch (Exception)
        {
            return false;                                                       // Возвращаем false, если возникла любая ошибка при проверке адреса регистрации
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateOfIssuePassport"></param>
    /// <returns></returns>
    static bool IsValidDateOfIssueOfPassport(DateOnly dateOfIssuePassport)
    {
        try
        {
            // Проверяем, что дата выдачи паспорта не раньше 01.01.1900 и не позже текущей даты
            if (dateOfIssuePassport < new DateOnly(1900, 1, 1) || dateOfIssuePassport.ToDateTime(new TimeOnly()) > DateTime.Now) return false;
            return true;
        }
        catch (Exception)
        {
            // Возвращаем false, если возникла любая ошибка при проверке даты выдачи паспорта
            return false;
        }
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return DivisionCode;
        yield return IssuedBy;
        yield return Series;
        yield return Number;
        yield return ResidenceAddress;
        yield return ResidentialAddress;
        yield return DateOfIssueOfPassport;
    }

    [GeneratedRegex(regexDivisionCode)]
    private static partial Regex RegDivCode();
    [GeneratedRegex(regexSeries)]
    private static partial Regex RegSeries();
    [GeneratedRegex(regexNumber)]
    private static partial Regex RegNumber();
}