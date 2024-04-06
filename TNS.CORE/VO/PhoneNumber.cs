using TNS.CORE.COMMON;

namespace TNS.CORE.VO
{
    public class PhoneNumber : ValueObject
    {
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }


    }
}