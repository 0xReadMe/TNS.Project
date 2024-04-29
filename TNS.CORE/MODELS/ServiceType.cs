using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.CORE.MODELS
{
    internal class ServiceType
    {
        public Guid     ServiceTypeId   { get; }     //  id типа услуги
        public string   ServiceTypeName { get; }     //  тип услуги

        private ServiceType() 
        {
        
        }

        public static Result<ServiceType> Create()
        {
            ServiceType result = new ServiceType();

            return Result.Success(result);
        }
    }
}
