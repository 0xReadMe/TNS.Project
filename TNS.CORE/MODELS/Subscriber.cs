using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
using TNS.CORE.MODELS;
using TNS.CORE.VO;

namespace TNS.Database;

public partial class Subscriber
{
    public const int ENTITY_MAX_LENGTH = 100;

    const string regexSubscriberNumber = @"(^[0-9]{2}[А-Я][0-9]{6}$)";


    public Guid Id { get; }
    public Guid PersonId { get; }
    public string SubscriberNumber { get; }
    public string ContractNumber { get; }
    public DateOnly DateOfContractConclusion { get; }
    public bool ContractType { get; }
    public string ReasonForTerminationOfContract { get; } = null!;
    public uint PersonalBill { get; }
    public string Services { get; } = null!;
    public DateOnly? DateOfTerminationOfTheContract { get; }
    public string SerialNumberOfEquipment { get; }

    private Subscriber(Guid id, Guid personId, string subscriberNumber, string contractNumber, DateOnly dateOfContractConclusion,
        bool contractType, string? reasonForTerminationOfContract, uint personalBill, string? services,
        DateOnly? dateOfTerminationOfTheContract, string serialNumberOfEquipment)
    {
        Id = id;
        PersonId = personId;
        SubscriberNumber = subscriberNumber;
        ContractNumber = contractNumber;
        DateOfContractConclusion = dateOfContractConclusion;
        ContractType = contractType;
        ReasonForTerminationOfContract = reasonForTerminationOfContract;
        PersonalBill = personalBill;
        Services = services;
        DateOfTerminationOfTheContract = dateOfTerminationOfTheContract;
        SerialNumberOfEquipment = serialNumberOfEquipment;
    }


    public static Result<Subscriber> Create(Guid id, Guid personId, string subscriberNumber, string contractNumber, DateOnly dateOfContractConclusion, 
        bool contractType, string? reasonForTerminationOfContract, uint personalBill, string? services, 
        DateOnly? dateOfTerminationOfTheContract, string serialNumberOfEquipment)
    {
        var invalid = "был введен неверно";
        if (!IsSubscriberNumber(subscriberNumber)) throw new ArgumentException($"Номер абонента {invalid}");
        if (string.IsNullOrWhiteSpace(contractNumber)) throw new ArgumentException($"Номер договора {invalid}");
        if (string.IsNullOrWhiteSpace(serialNumberOfEquipment)) throw new ArgumentException($"Серийный номер оборудования {invalid}");
        if (dateOfContractConclusion.ToDateTime(new TimeOnly()) > DateTime.Now) throw new ArgumentException($"Дата завершения контракта {invalid}");

        Subscriber subscriber = new(id, personId, subscriberNumber, contractNumber, dateOfContractConclusion, contractType, reasonForTerminationOfContract, personalBill, services, dateOfTerminationOfTheContract, serialNumberOfEquipment);

        return Result.Success(subscriber);
    }

    static bool IsSubscriberNumber(string subscriberNumber) 
    {
        if (string.IsNullOrWhiteSpace(subscriberNumber)) return false;
        return RegSubNum().Match(subscriberNumber).Success;
    }
    static bool IsContractNumber(string contractNumber) 
    {
    
    }
    [GeneratedRegex(regexSubscriberNumber)]
    private static partial Regex RegSubNum();
}
