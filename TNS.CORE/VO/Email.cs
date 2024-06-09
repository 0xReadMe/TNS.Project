using CSharpFunctionalExtensions;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TNS.CORE.VO
{
    public class Email : ValueObject
    {
        public string email { get; }

        private Email(string email) => this.email = email;

        public static Result<Email> Create(string email)
        {
            if (!IsValidEmail(email)) return Result.Failure<Email>("Некорректный E-mail.");

            return Result.Success<Email>(new(email));
        }

        /// <summary>
        /// Проверка валидности входного e-mail.
        /// <para>
        /// Valid: david.jones@proseware.com
        ///  Valid: d.j@server1.proseware.com
        ///  Valid: jones@ms1.proseware.com
        ///  Valid: j@proseware.com9
        ///  Valid: js#internal@proseware.com
        ///  Valid: j_9@[129.126.118.1]
        ///  Valid: js@proseware.com9
        ///  Valid: j.s@server1.proseware.com
        ///  Valid: "j\"s\""@proseware.com
        ///  Valid: js@contoso.中国
        ///  Invalid: j.@server1.proseware.com
        ///  Invalid: j..s@proseware.com
        ///  Invalid: js*@proseware.com
        ///  Invalid: js@proseware..com 
        /// </para>
        /// </summary>
        /// <param name="email">Входной e-mail</param>
        /// <returns>True - e-mail корректен</returns>
        static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", 
                    DomainMapper, RegexOptions.None, 
                    TimeSpan.FromMilliseconds(200));                            //  нормализация домена

                static string DomainMapper(Match match)                         //  рассматриваем доменную часть письма и нормализуем ее
                {
                    var idn = new IdnMapping();                                 //  конвертирования доменных имен Unicode
                    string domainName = idn.GetAscii(match.Groups[2].Value);    //  извлекаем и обрабатываем доменное имя (выбрасывает ArgumentException, если оно недействительно)
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return email;
        }
    }
}