using CSharpFunctionalExtensions;
using TNS.CORE.VO;

namespace TNS.CORE.MODELS
{
    public class Person
    {
        public Guid         Id              { get; }    //  id человека
        public Guid         SubscriberId    { get; set;}//  id абонента
        public string       FirstName       { get; }    //  имя
        public string       MiddleName      { get; }    //  отчество
        public string       LastName        { get; }    //  фамилия
        public char         Gender          { get; }    //  пол
        public DateOnly     DOB             { get; }    //  дата рождения
        public PhoneNumber  PhoneNumber     { get; }    //  номер телефона
        public Email        Email           { get; }    //  e-mail
        public Passport     Passport        { get; }    //  паспорт

        private Person(Guid         id,
                       string       firstName,
                       string       middleName,
                       string       lastName,
                       char         gender,
                       DateOnly     DOB,
                       PhoneNumber  phoneNumber,
                       Email        email,
                       Passport     passport) 
        {
            Id              = id;
            FirstName       = firstName;
            MiddleName      = middleName;
            LastName        = lastName;
            Gender          = gender;
            this.DOB        = DOB;
            PhoneNumber     = phoneNumber;
            Email           = email;
            Passport        = passport;
        }

        public static Result<Person> Create(string      firstName,
                                            string      middleName,
                                            string      lastName,
                                            char        gender,
                                            DateOnly    DOB,
                                            PhoneNumber phoneNumber,
                                            Email       email,
                                            Passport    passport)
        {
            
            if (!IsValidFullName(firstName, middleName, lastName))          return Result.Failure<Person>("FullName is invalid.");
            if (!IsValidGender(gender))                                     return Result.Failure<Person>("Gender is invalid.");
            if (!IsValidDOB(DOB))                                           return Result.Failure<Person>("DOB is invalid.");
            if (PhoneNumber.Create(phoneNumber.Number).IsFailure)           return Result.Failure<Person>("Phone number is invalid.");
            if (Email.Create(email.email).IsFailure)                        return Result.Failure<Person>("E-mail is invalid.");
            if (Passport.Create(passport.DivisionCode,
                                passport.IssuedBy,
                                passport.Series,
                                passport.Number,
                                passport.ResidenceAddress,
                                passport.ResidentialAddress,
                                passport.DateOfIssueOfPassport).IsFailure)  return Result.Failure<Person>("Passport is invalid.");

            Guid id = Guid.NewGuid();
            return Result.Success<Person>(new (id, firstName, middleName, lastName, gender, DOB, phoneNumber, email, passport));
        }

        /// <summary>
        /// Добавление айди абонента к существующему человеку
        /// </summary>
        /// <param name="person">Сущность человека</param>
        /// <param name="subId">Айди существующего абонента</param>
        /// <returns>Сущность человека с добавленным айди существующего абонента</returns>
        public static Result<Person> AddSubscriberId(Person person, Guid subId) 
        {
            person.SubscriberId = subId;
            return Result.Success(person);
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
                int age = (DateOnly.FromDateTime(DateTime.Now)).Year - dOB.Year;
                if (age < 18)                                   return false;        //  Проверяем, что человеку не меньше 18 лет
                if (dOB > DateOnly.FromDateTime(DateTime.Now))  return false;        //  Проверяем, что дата рождения не в будущем
                return true;
            }
            catch (Exception)
            {
                return false;                                                        //  Возвращаем false, если возникла любая ошибка при проверке даты рождения
            }
        }

        /// <summary>
        /// Валидация пола
        /// </summary>
        /// <param name="gender">"М" или "Ж" - пол человека</param>
        /// <returns>True - пол человека корректен</returns>
        private static bool IsValidGender(char gender)
        {
            try
            {
                if (gender == '\0') return false;                           //  символ гендера не пустой

                char genderUppercase = char.ToUpper(gender);
                return genderUppercase == 'М' || genderUppercase == 'Ж';    //  символ гендера - "М" или "Ж" (без учета регистра)
            }
            catch (Exception)
            {
                return false;                                               //  Возвращаем false, если возникла любая ошибка при проверке гендера
            }
        }

        /// <summary>
        /// Валидация ФИО
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="lastName">Фамилия</param>
        /// <returns>True - ФИО корректно.</returns>
        private static bool IsValidFullName(string firstName, string middleName, string lastName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(middleName) || string.IsNullOrWhiteSpace(lastName))   return false;   //  имя, фамилия и отчество не пустые
                if (!ContainsOnlyLetters(firstName) || !ContainsOnlyLetters(middleName) || !ContainsOnlyLetters(lastName))                  return false;   //  имя, фамилия и отчество состоят только из букв
                if (firstName.Length > 50 || middleName.Length > 50 || lastName.Length > 50)                                                return false;   //  длина каждого из полей не превышает 50 символов

                return true;
            }
            catch (Exception)
            {
                return false;                                                                                                                               // Возвращаем false, если возникла любая ошибка при проверке ФИО
            }
        }

        /// <summary>
        /// Проверяем, что input содержит только буквы
        /// </summary>
        /// <param name="input">Строка, которую нужно проверить</param>
        /// <returns>True - содержит только буквы</returns>
        private static bool ContainsOnlyLetters(string input) => System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Zа-яА-Я]+$");                  // строка состоит только из букв (без цифр, пробелов и специальных символов)
    }
}