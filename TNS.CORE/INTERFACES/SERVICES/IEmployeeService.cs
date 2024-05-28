using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.CORE.MODELS;

namespace TNS.CORE.INTERFACES.SERVICES
{
    public interface IEmployeeService
    {
        Task<string> Login(string phoneNumber, string password);
        Task<List<Employee>> GetAll();
    }
}
