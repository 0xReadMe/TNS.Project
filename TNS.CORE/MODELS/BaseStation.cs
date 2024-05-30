using CSharpFunctionalExtensions;
using System.Runtime.Intrinsics.Arm;

namespace TNS.CORE.MODELS
{
    public class BaseStation
    {
        public Guid     Id                      { get; }    //  id
        public Guid     AddressId               { get; }    //  id адреса станции
        public string   BaseStationName         { get; }    //  название БС
        public double   S                       { get; }    //  площадь зоны покрытия
        public int      Frequency               { get; }    //  частота, Гц
        public string   TypeAntenna             { get; }    //  тип антенны
        public int      Handover                { get; }    //  показатель хендовера
        public string   CommunicationProtocol   { get; }    //  стандарт связи


        private BaseStation(Guid    id,
                            Guid    adressId,
                            string  baseStationName,
                            double  S,
                            int     frequency,
                            string  typeAntenna,
                            int     handover,
                            string  communictationProtocol) 
        {
            Id                      = id;
            AddressId               = adressId;
            BaseStationName         = baseStationName;
            this.S                  = S; 
            Frequency               = frequency;
            TypeAntenna             = typeAntenna;
            Handover                = handover;
            CommunicationProtocol   = communictationProtocol;
        }

        public static Result<BaseStation> Create(Guid   id,
                                                 Guid   adressId,
                                                 string baseStationName,
                                                 double S,
                                                 int    frequency,
                                                 string typeAntenna,
                                                 int    handover,
                                                 string communictationProtocol) 
        {
            BaseStation result = new BaseStation(id,
                                                 adressId,
                                                 baseStationName,
                                                 S,
                                                 frequency,
                                                 typeAntenna,
                                                 handover,
                                                 communictationProtocol);

            return Result.Success(result);
        }
    }
}
