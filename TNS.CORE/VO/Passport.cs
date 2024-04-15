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

        private Passport(string divisionCode, string issuedBy, int series, int number, string residenceAddress, string residentialAddress, DateOnly dateOfIssueOfPassport) 
        {
            DivisionCode = divisionCode;
            IssuedBy = issuedBy;
            Series = series;
            Number = number;
            ResidenceAddress = residenceAddress;
            ResidentialAddress = residentialAddress;
            DateOfIssueOfPassport = dateOfIssueOfPassport;
        }

        public static Result<Passport, Error> Create(string divisionCode, string issuedBy, int series, int number, string residenceAddress, string residentialAddress, DateOnly dateOfIssueOfPassport) 
        {
            if (IsValidDateOfIssueOfPassport(dateOfIssueOfPassport)) throw new ArgumentException("");
            if (IsValidDivisionCode(divisionCode)) throw new ArgumentException("");
            if (IsValidIssuedBy(issuedBy)) throw new ArgumentException("");
            if (IsValidNumber(number)) throw new ArgumentException("");
            if (IsValidSeries(series)) throw new ArgumentException("");
            if (IsValidResidenceAddress(residenceAddress)) throw new ArgumentException("");
            if (IsValidResidentialAddress(residentialAddress)) throw new ArgumentException("");

            return new Passport(divisionCode, issuedBy, series, number, residenceAddress, residentialAddress, dateOfIssueOfPassport);
        }

        const string regexDivisionCode = @"^\d{3}\-\d{3}$";
        const string regexSeries = @"(^\d{4}$)";
        const string regexNumber = @"(^\d{6}$)";


        static bool IsValidIssuedBy(string issuedBy)
        {
            return true;
        }

        static bool IsValidDivisionCode(string divisionCode) => RegDivCode().Match(divisionCode).Success;
        static bool IsValidSeries(int series) => RegSeries().Match(series.ToString()).Success;
        static bool IsValidNumber(int number) => RegNumber().Match(number.ToString()).Success;

        static bool IsValidResidenceAddress(string residenceAddress)
        {
            return true;
        }

        static bool IsValidResidentialAddress(string residentialAddress)
        {
            return true;
        }

        static bool IsValidDateOfIssueOfPassport(DateOnly dateOfIssuePassport)
        {
            return true;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return DivisionCode;
            yield return IssuedBy;
            yield return Series;
            yield return Number;
            yield return ResidenceAddress;
            yield return ResidentialAddress;
            yield return DateOfIssueOfPassport;
        }

        [GeneratedRegex(regexDivisionCode)]
        private static partial Regex RegDivCode();
        [GeneratedRegex(regexSeries)]
        private static partial Regex RegSeries();
        [GeneratedRegex(regexNumber)]
        private static partial Regex RegNumber();
    }
}