using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
namespace TNS.CORE.VO
{
    public partial class PhoneNumber : ValueObject
    {
        private const string phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

        public string Number { get; }

        private PhoneNumber(string number) => Number = number;

        public static Result<PhoneNumber> Create(string input)
        {
            if (!IsPhoneNumber(input)) return Result.Failure<PhoneNumber>("Phone number invalid.");

            return Result.Success(new PhoneNumber(input));
        }

        public static bool IsPhoneNumber(string number)
        {
            if (string.IsNullOrEmpty(number))           return false;
            if (!MyRegex().Match(number).Success)       return false;
            return true;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Number;
        }

        [GeneratedRegex(phoneRegex)]
        private static partial Regex MyRegex();
    }
}