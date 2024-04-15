using CSharpFunctionalExtensions;
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
                throw new ArgumentException("Нерабочий E-mail или присутствуют лишние символы!");

            return new Email(email);
        }

        static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
                return false; // suggested by @TK-421
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
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