using CSharpFunctionalExtensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TNS.CORE.VO
{
    public class Email : ValueObject
    {

        public string email { get; }

        private Email(string email)
        {
            this.email = email;
        }

        public static Result<Email, Error> Create(string input)
        {
            //if (!IsValidEmail(input)) 

            //if (string.IsNullOrWhiteSpace(input))
            //return Errors.General.ValueIsInvalid();

            //if (Regex.IsMatch(input, phoneRegex) == false)
            //return Errors.General.ValueIsInvalid();

            return new Email(input);
        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
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