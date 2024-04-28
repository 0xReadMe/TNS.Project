using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    public class BaseStation
    {
        public          Guid Id { get; }              // id
        public          Guid AddressId { get; }       // id адреса станции
        public string   BaseStationName { get; }      // название БС
        public double   S { get; }                    // площадь зоны покрытия
        public int      Frequency { get; }            // частота, Гц
        public string   TypeAntenna { get; }          // тип антенны
        public int      Handover { get; }             // показатель хендовера
        public string   CommunicationProtocol { get; }// стандарт связи


        private BaseStation() 
        {

        }

        public static Result<BaseStation> Create() 
        {
            BaseStation result = new BaseStation();

            return Result.Success(result);
        }
    }
}
