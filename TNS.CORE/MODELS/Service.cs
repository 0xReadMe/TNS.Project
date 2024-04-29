using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.CORE.MODELS
{
    internal class Service
    {
        public Guid     ServiceId   { get; }    //  id услуги
        public string   ServiceName { get; }    //  имя услуги

        private Service() 
        {
        
        }

        public static Result<Service> Create()
        {
            Service result = new Service();

            return Result.Success(result);
        }
    }
}
