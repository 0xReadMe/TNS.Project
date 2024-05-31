using CSharpFunctionalExtensions;
using TNS.CORE.VO;

namespace TNS.CORE.MODELS
{
    public class Employee
    {
        public Guid         Id              { get; }                    //  id сотрудника
        public Guid         PositionId      { get; }                    //  id должности
        public string       FullName        { get; }                    //  ФИО сотрудника
        public string       PhotoId         { get; }                    //  путь к фото
        public PhoneNumber  Login           { get; }                    //  авторизация
        public string       PasswordHash    { get; }                    //  авторизация

        private Employee(Guid           id,
                         Guid           positionId,
                         string         fullName,
                         string         photoId,
                         PhoneNumber    login,
                         string         passwordHash)
        {
            Id              = id;
            FullName        = fullName; 
            PositionId      = positionId; 
            PhotoId         = photoId;
            Login           = login;
            PasswordHash    = passwordHash;
        }

        public static Result<Employee> Create(Guid          id,
                                              Guid          positionId,
                                              string        fullName,
                                              string?       photoId,
                                              PhoneNumber   login,
                                              string        passwordHash)
        {
            if (IsValidFullName(fullName))                  return Result.Failure<Employee>("Full Name invalid.");      //  валидация ФИО
            if (PhoneNumber.Create(login.Number).IsFailure) return Result.Failure<Employee>("Login invalid.");          //  повторная валидация логина (номер телефона)
                                                            photoId ??= "our empty photo";                              //  если фото = null, ставим заглушку
            if (IsValidPhotoId(photoId))                    return Result.Failure<Employee>("Photo path invalid.");     //  валидация пути к фото
            if (IsValidPasswordHash(passwordHash))          return Result.Failure<Employee>("Password hash invalid.");  //  валидация пути к фото

            return Result.Success(new Employee(id,
                                               positionId,
                                               fullName,
                                               photoId,
                                               login,
                                               passwordHash));
        }

        /// <summary>
        /// Валидация пути к фото
        /// </summary>
        /// <param name="avatarPath">Путь к фото</param>
        /// <returns>True - путь корректен.</returns>
        private static bool IsValidPhotoId(string avatarPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(avatarPath))  return false;                            // Проверяем, что путь не пуст
                if (!File.Exists(avatarPath))               return false;                            // Проверяем, что файл существует

                // Проверяем, что файл имеет допустимое расширение (например, .jpg, .png, .gif)
                string extension = Path.GetExtension(avatarPath).ToLower();
                if (extension != ".jpg" && extension != ".png" && extension != ".gif") return false;

                // Проверяем, что размер файла не превышает максимально допустимый (например, 2 МБ)
                FileInfo fileInfo = new FileInfo(avatarPath);
                if (fileInfo.Length > 4 * 1024 * 1024) return false;                                // 4 МБ

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
                if (!string.IsNullOrWhiteSpace(part) && !ContainsOnlyLetters(part)) return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация хеша пароля
        /// </summary>
        /// <param name="passwordHash">Хеш</param>
        /// <returns>True - хеш корректен.</returns>
        public static bool IsValidPasswordHash(string passwordHash)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(passwordHash))                                    return false;   // Проверяем, что хеш не пустой
                if (passwordHash.Length != 64)                                                  return false;   // Проверяем, что длина хеша соответствует ожидаемой длине (например, 64 символа для SHA-256)
                if (!System.Text.RegularExpressions.Regex.IsMatch(passwordHash, "^[0-9a-f]+$")) return false;   // Проверяем, что хеш состоит только из допустимых символов (0-9, a-f)
                return true;
            }
            catch (Exception)
            {
                return false;                                                                                   // Возвращаем false, если возникла любая ошибка при проверке хеша
            }
        }

        /// <summary>
        /// Проверяем, что input содержит только буквы
        /// </summary>
        /// <param name="input">Строка, которую нужно проверить</param>
        /// <returns>True - содержит только буквы</returns>
        private static bool ContainsOnlyLetters(string input) 
            => string.IsNullOrWhiteSpace(input) || System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Zа-яА-Я]+$");
    }
}