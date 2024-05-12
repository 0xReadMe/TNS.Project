using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace TNS.CORE.MODELS
{
    public partial class Subscriber
    {
        public const int ENTITY_MAX_LENGTH              = 100;
        public const int SUBSCRIBER_NUMBER_MAX_LENGTH   = 9;
        public const int CONTRACT_NUMBER_MAX_LENGTH     = 16;

        public Guid         Id                              { get; }    //  id абонента
        public Guid         PersonId                        { get; }    //  id человека
        public string       SubscriberNumber                { get; }    //  номер абонента
        public string       ContractNumber                  { get; }    //  номер договора
        public bool         ContractType                    { get; }    //  тип договора
        public string       ReasonForTerminationOfContract  { get; }    //  причина расторжения договора
        public uint         PersonalBill                    { get; }    //  лицевой счет
        public string       Services                        { get; }    //  услуги
        public DateOnly     DateOfContractConclusion        { get; }    //  дата заключения договора
        public DateOnly?    DateOfTerminationOfTheContract  { get; }    //  дата расторжения договора
        public string       SerialNumberOfEquipment         { get; }    //  серийный номер оборудования

        const string regexSubscriberNumber = @"(^[0-9]{2}[А-Я][0-9]{6}$)";

        private Subscriber(Guid      id,
                           Guid      personId,
                           DateOnly  dateOfContractConclusion,
                           DateOnly? dateOfTerminationOfTheContract,
                           string    subscriberNumber,
                           string    contractNumber,
                           string    reasonForTerminationOfContract,
                           string    serialNumberOfEquipment,
                           string    services,
                           bool      contractType,
                           uint      personalBill)
        {
            Id                              = id;
            PersonId                        = personId;
            SubscriberNumber                = subscriberNumber;
            ContractNumber                  = contractNumber;
            DateOfContractConclusion        = dateOfContractConclusion;
            ContractType                    = contractType;
            ReasonForTerminationOfContract  = reasonForTerminationOfContract;
            PersonalBill                    = personalBill;
            Services                        = services;
            DateOfTerminationOfTheContract  = dateOfTerminationOfTheContract;
            SerialNumberOfEquipment         = serialNumberOfEquipment;
        }


        public static Result<Subscriber> Create(Guid      personId,
                                                DateOnly  dateOfContractConclusion,
                                                DateOnly? dateOfTerminationOfTheContract,
                                                string?   reasonForTerminationOfContract,
                                                string    serialNumberOfEquipment,
                                                string    services,
                                                bool      contractType,
                                                uint      personalBill)
        {

            Guid id = Guid.NewGuid();
            string subscriberNumber = "";
            string contractNumber = "";


            if (!IsSubscriberNumber(subscriberNumber)) throw new ArgumentException(ErrorMessage("номер абонента"));
            if (string.IsNullOrWhiteSpace(contractNumber)) throw new ArgumentException(ErrorMessage("номер договора"));
            if (string.IsNullOrWhiteSpace(serialNumberOfEquipment)) throw new ArgumentException(ErrorMessage("серийный номер оборудования"));
            if (dateOfContractConclusion.ToDateTime(new TimeOnly()) > DateTime.Now) throw new ArgumentException(ErrorMessage("дата завершения контракта"));

            Subscriber subscriber = new(id, 
                                        personId, 
                                        dateOfContractConclusion, 
                                        dateOfTerminationOfTheContract, 
                                        subscriberNumber, 
                                        contractNumber, 
                                        reasonForTerminationOfContract, 
                                        serialNumberOfEquipment, 
                                        services, 
                                        contractType, 
                                        personalBill);

            return Result.Success(subscriber);
        }

        private static bool IsSubscriberNumber(string subscriberNumber)
        {
            if (string.IsNullOrWhiteSpace(subscriberNumber)) return false;
            return RegSubNum().Match(subscriberNumber).Success;
        }
        //static bool IsContractNumber(string contractNumber) 
        //{
        //
        //}

        private static string ErrorMessage(string msg) => $"Ошибка: Не получилось создать {msg}.";

        [GeneratedRegex(regexSubscriberNumber)]
        private static partial Regex RegSubNum();
    }
}