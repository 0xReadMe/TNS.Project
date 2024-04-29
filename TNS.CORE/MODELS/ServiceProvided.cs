using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.CORE.MODELS
{
    internal class ServiceProvided
    {
        public Guid     ServiceProvidedId   { get; }    //  id оказываемой услуги
        public string   ServiceProvidedName { get; }    //  оказываемая услуга

        private ServiceProvided() 
        {
        
        }

        public static Result<ServiceProvided> Create()
        {
            ServiceProvided result = new ServiceProvided();

            return Result.Success(result);
        }
    }
}
