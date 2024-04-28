using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.CORE.MODELS
{
    internal class BaseStationAddress
    {
        public Guid     Id { get; }                   // id
        public Guid     BaseStationId { get; }        // id адреса станции
        public string   Address { get; }              // адрес площадки
        public string   Location { get; }             // место расположения

        private BaseStationAddress() 
        {
        
        }

        public static Result<BaseStationAddress> Create()
        {
            BaseStationAddress result = new BaseStationAddress();

            return Result.Success(result);
        }
    }
}
