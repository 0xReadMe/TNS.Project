using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TNS.CORE.VO
{
    public partial class PhoneNumber : ValueObject
    {
        private const string phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

        public string Number { get; }

        private PhoneNumber(string number) => Number = number;

        public static Result<PhoneNumber, Error> Create(string input)
        {
            //if (!IsPhoneNumber(input)) 
                
            //if (string.IsNullOrWhiteSpace(input))
                //return Errors.General.ValueIsInvalid();

            //if (Regex.IsMatch(input, phoneRegex) == false)
                //return Errors.General.ValueIsInvalid();

            return new PhoneNumber(input);
        }

        public static bool IsPhoneNumber(string number) => MyRegex().Match(number).Success;

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Number;
        }

        [GeneratedRegex(phoneRegex)]
        private static partial Regex MyRegex();
    }
}