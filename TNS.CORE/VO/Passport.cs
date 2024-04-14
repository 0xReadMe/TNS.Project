using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TNS.CORE.VO
{
    public partial class Passport : ValueObject
    {
        public string DivisionCode { get; }
        public string IssuedBy { get; }
        public int Series  { get; }
        public int Number { get; }
        public string ResidenceAddress { get; }
        public string ResidentialAddress { get; }
        public DateOnly DateOfIssueOfPassport { get; }

        const string regexDivisionCode = @"^\d{3}\-\d{3}$";
        const string regexSeries = @"(^\d{4}$)";
        const string regexNumber = @"(^\d{6}$)";


        bool IsValidIssuedBy(string input)
        {
            return true;
        }

        bool IsValidDivisionCode(string input) => RegDivCode().Match(input).Success;
        bool IsValidSeries(int input) => RegSeries().Match(input.ToString()).Success;
        bool IsValidNumber(int input) => RegNumber().Match(input.ToString()).Success;

        bool IsValidResidenceAddress(string input)
        {
            return true;
        }

        bool IsValidResidentialAddress(string input)
        {
            return true;
        }

        bool IsValidDateOfIssueOfPassport(DateOnly input)
        {
            return true;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        [GeneratedRegex(regexDivisionCode)]
        private static partial Regex RegDivCode();
        [GeneratedRegex(regexSeries)]
        private static partial Regex RegSeries();
        [GeneratedRegex(regexNumber)]
        private static partial Regex RegNumber();
    }
}