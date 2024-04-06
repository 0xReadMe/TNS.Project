using TNS.CORE.COMMON;

namespace TNS.CORE.VO
{
    public class Email : ValueObject
    {
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}