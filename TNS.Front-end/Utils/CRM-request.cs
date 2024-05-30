using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Front_end.Utils
{
    public class CRM_request
    {
        public string Id { get; set; } = null!;
        public string NumberRequest { get; set; }
        public string AbonentNumber { get; set; } = null!;
        public string Service { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string TypeEquipment { get; set; } = null!;
    }
}
