using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.CORE.VO;

namespace TNS.CORE.MODELS
{
    public class Person
    {
        public Guid Id { get; }
        public Guid SubscriberId { get; }
        public string FirstName { get; } = string.Empty;
        public string MiddleName { get; } = null!;
        public string LastnameName { get; } = string.Empty;
        public char Gender { get; }
        public DateTime DOB { get; }
        public PhoneNumber PhoneNumber { get; }
        public Email Email { get; } = null!;
        public Passport Passport { get; }
    }
}
