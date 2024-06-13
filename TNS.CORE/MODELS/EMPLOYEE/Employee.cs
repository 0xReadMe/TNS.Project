using CSharpFunctionalExtensions;
using TNS.CORE.VO;
using System.Text.RegularExpressions;
namespace TNS.CORE.MODELS.EMPLOYEE;

public class Employee
{
    public Guid         Id { get; }                    //  id сотрудника
    public string       FullName { get; }                    //  ФИО сотрудника
    public string       PhotoId { get; }                    //  путь к фото
    public DateOnly     DateOfBirth { get; }                    //  дата рождения
    public string?      Telegram { get; }                    //  telegram
    public Email        Email { get; }                    //  e-mail
    public PhoneNumber  Login { get; }                    //  авторизация (номер телефона)
    public string       PasswordHash { get; }                    //  авторизация (пароль)

    private Employee(Guid id,
                     string fullName,
                     string photoId,
                     string? telegram,
                     DateOnly DOB,
                     Email email,
                     PhoneNumber login,
                     string passwordHash)
    {
        Id = id;
        FullName = fullName;
        PhotoId = photoId;
        Telegram = telegram;
        Email = email;
        DateOfBirth = DOB;
        Login = login;
        PasswordHash = passwordHash;
    }

    public static Result<Employee> Create(string fullName,
                                          string? photoId,
                                          string? telegram,
                                          DateOnly DOB,
                                          Email email,
                                          PhoneNumber login,
                                          string passwordHash)
    {
        if (!IsValidFullName(fullName))                 return Result.Failure<Employee>("Full Name invalid.");      //  валидация ФИО
        if (PhoneNumber.Create(login.Number).IsFailure) return Result.Failure<Employee>("Login invalid.");          //  повторная валидация логина (номер телефона)

        photoId ??= "our empty photo";                                                                              //  если фото = null, ставим заглушку
        if (!IsValidPhotoId(photoId))                   return Result.Failure<Employee>("Photo path invalid.");     //  валидация пути к фото

        if (!IsValidPasswordHash(passwordHash))         return Result.Failure<Employee>("Password hash invalid.");  //  валидация хеша
        if (Email.Create(email.email).IsFailure)        return Result.Failure<Employee>("E-mail invalid");          //  валидация e-mail
        if (!IsValidDOB(DOB))                           return Result.Failure<Employee>("DOB invalid");

        telegram ??= "@TNS_COMPANY";
        if (!IsValidTelegram(telegram))                 return Result.Failure<Employee>("Telegram invalid.");       //  валидация телеграмм

        Guid id = Guid.NewGuid();
        return Result.Success(new Employee(id, fullName, photoId, telegram, DOB, email, login, passwordHash));
    }

    /// <summary>
    /// Валидация телеграмм-юзернейма
    /// </summary>
    /// <param name="telegram">Telegram-юзернейм</param>
    /// <returns>True - юзернейм корректен</returns>
    private static bool IsValidTelegram(string? telegram)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(telegram)) return false;   //  юзернейм не пустой
            if (telegram[0] != '@') return false;   //  юзернейм начинается с символа "@"
            if (telegram.Length - 1 > 32) return false;   //  длина юзернейма без "@" не превышает 32 символа
            if (!Regex.IsMatch(telegram.Substring(1), "^[a-zA-Z0-9_]+$")) return false;   //  юзернейм без "@" содержит только латинские буквы, цифры и символы подчёркивания

            return true;
        }
        catch (Exception)
        {
            return false; // Возвращаем false, если возникла любая ошибка при проверке юзернейма
        }
    }

    /// <summary>
    /// Валидация даты рождения
    /// </summary>
    /// <param name="dOB">Дата рождения</param>
    /// <returns>True - дата рождения валидна</returns>
    private static bool IsValidDOB(DateOnly dOB)
    {
        try
        {
            int age = DateOnly.FromDateTime(DateTime.Now).Year - dOB.Year;
            if (age < 18) return false;        //  Проверяем, что человеку не меньше 18 лет
            if (dOB > DateOnly.FromDateTime(DateTime.Now)) return false;        //  Проверяем, что дата рождения не в будущем
            return true;
        }
        catch (Exception)
        {
            return false;                                                       //  Возвращаем false, если возникла любая ошибка при проверке даты рождения
        }
    }

    /// <summary>
    /// Валидация пути к фото
    /// </summary>
    /// <param name="avatarPath">Путь к фото</param>
    /// <returns>True - путь корректен.</returns>
    private static bool IsValidPhotoId(string avatarPath)
    {
        // valid: C:\\Users\\User\\Documents\\avatar.jpg
        try
        {
            if (string.IsNullOrWhiteSpace(avatarPath)) return false;                            // Проверяем, что путь не пуст

            // Проверяем, что файл имеет допустимое расширение (например, .jpg, .png, .gif)
            string extension = Path.GetExtension(avatarPath).ToLower();
            if (extension != ".jpg" && extension != ".png") return false;

            return true;
        }
        catch (Exception)
        {
            return false;   // Возвращаем false, если возникла любая ошибка при проверке пути
        }
    }

    /// <summary>
    /// Валидация ФИО
    /// </summary>
    /// <param name="fullName">ФИО</param>
    /// <returns>True - ФИО корректное</returns>
    private static bool IsValidFullName(string fullName)
    {
        string[] nameParts = fullName.Split(' ');                                               //  Разбиваем ФИО на отдельные составляющие
        if (nameParts.Length != 3) return false;                                                //  Проверяем, что ФИО состоит из трёх частей
        foreach (string part in nameParts)                                                      //  Проверяем, что каждая часть содержит только буквы
        {
            if (string.IsNullOrWhiteSpace(part) || !Regex.IsMatch(part, "^[a-zA-Zа-яА-Я]+$")) return false;
        }
        return true;
    }

    /// <summary>
    /// Валидация хеша пароля
    /// </summary>
    /// <param name="passwordHash">Хеш</param>
    /// <returns>True - хеш корректен.</returns>
    private static bool IsValidPasswordHash(string passwordHash)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(passwordHash)) return false;   // Проверяем, что хеш не пустой
            if (passwordHash.Length != 64) return false;   // Проверяем, что длина хеша соответствует ожидаемой длине (например, 64 символа для SHA-256)
            if (!System.Text.RegularExpressions.Regex.IsMatch(passwordHash, "^[0-9a-f]+$")) return false;   // Проверяем, что хеш состоит только из допустимых символов (0-9, a-f)
            return true;
        }
        catch (Exception)
        {
            return false;                                                                                   // Возвращаем false, если возникла любая ошибка при проверке хеша
        }
    }
}