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

        public static Result<Email, Error> Create(string email)
        {
            if (!IsValidEmail(email)) 
                throw new ArgumentException("Невалидный E-mail или присутствуют лишние символы!");

            return new Email(email);
        }

        static bool IsValidEmail(string email)
        //       Valid: david.jones@proseware.com
        //       Valid: d.j@server1.proseware.com
        //       Valid: jones@ms1.proseware.com
        //       Invalid: j.@server1.proseware.com
        //       Valid: j@proseware.com9
        //       Valid: js#internal@proseware.com
        //       Valid: j_9@[129.126.118.1]
        //       Invalid: j..s@proseware.com
        //       Invalid: js*@proseware.com
        //       Invalid: js@proseware..com
        //       Valid: js@proseware.com9
        //       Valid: j.s@server1.proseware.com
        //       Valid: "j\"s\""@proseware.com
        //       Valid: js@contoso.中国
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
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