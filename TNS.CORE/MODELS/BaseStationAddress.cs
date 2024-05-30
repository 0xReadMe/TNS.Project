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
        public Guid     Id              { get; }    //  id
        public Guid     BaseStationId   { get; }    //  id адреса станции
        public string   Address         { get; }    //  адрес площадки
        public string   Location        { get; }    //  место расположения

        private BaseStationAddress(Guid     id,
                                   Guid     baseStationId,
                                   string   address,
                                   string   location) 
        {
            Id              = id;
            BaseStationId   = baseStationId;
            Address         = address;
            Location        = location;
        }

        public static Result<BaseStationAddress> Create(Guid    id,
                                                        Guid    baseStationId,
                                                        string  address,
                                                        string  location)
        {
            BaseStationAddress result = new BaseStationAddress(id,
                                                               baseStationId,
                                                               address,
                                                               location);

            return Result.Success(result);
        }
    }
}
