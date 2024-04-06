using TNS.CORE.COMMON;

namespace TNS.CORE.VO
{
    public class Passport : ValueObject
    {
        //public string DivisionCode { get; } = null!;
        //public string IssuedBy { get; } = null!;
        //public int Series  { get; set; }
        //public int Number { get; set; }
        //residence_address
        //residential_address
        //public DateOnly DateOfIssueOfPassport { get; }


        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}