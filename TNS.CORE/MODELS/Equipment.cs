using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    public class Equipment
    {
        public Guid     Id                     { get; }    //  Id оборудования
        public string   SerialNumber           { get; }    //  серийный номер
        public string   Name                   { get; }    //  название
        public double   Frequency              { get; }    //  частота
        public string   AttenuationCoefficient { get; }    //  коэффициент затухания
        public string   DTT                    { get; }    //  Data Transfer Technology (технология передачи данных)
        public string   Address                { get; }    //  расположение

        public Equipment(Guid   id,
                         string serialNumber,
                         string name,
                         double frequency,
                         string attenuationCoefficient,
                         string DTT,
                         string address) 
        {
            Id                      = id;
            SerialNumber            = serialNumber;
            Name                    = name;
            Frequency               = frequency;
            AttenuationCoefficient  = attenuationCoefficient;
            this.DTT                = DTT;
            Address                 = address;
        }

        public static Result<Equipment> Create(Guid     id,
                                               string   serialNumber,
                                               string   name,
                                               double   frequency,
                                               string   attenuationCoefficient,
                                               string   DTT,
                                               string   address)
        {
            Equipment result = new Equipment(id,
                                             serialNumber,
                                             name,
                                             frequency,
                                             attenuationCoefficient,
                                             DTT,
                                             address);

            return Result.Success(result);
        }
    }
}
