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

        public Equipment() 
        {
            
        }

        public static Result<Equipment> Create()
        {
            Equipment result = new Equipment();

            return Result.Success(result);
        }
    }
}
