using CSharpFunctionalExtensions;
using TNS.CORE.MODELS;
using TNS.CORE.VO;

namespace TNS.Database;

public class Subscriber
{
    public const int ENTITY_MAX_LENGTH = 100;

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
    public string SerialNumberOfEquipment { get; } = null!;

    private Subscriber(
        Guid id, Guid personId, string subscriberNumber, string contractNumber,
        DateOnly dateOfContractConclusion, bool contractType,
        string reasonForTerminationOfContract, uint personalBill,
        string services, DateOnly dateOfTerminationOfTheContract,
        string serialNumberOfEquipment
        )
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

    public static Result<Subscriber> Create(
        Guid id,
        Guid personId,
        string subscriberNumber,
        string contractNumber,
        DateOnly dateOfContractConclusion,
        bool ContractType,
        string reasonForTerminationOfContract,
        uint personalBill,
        string services,
        DateOnly dateOfTerminationOfTheContract,
        string serialNumberOfEquipment
        )
    {
        //validation data IsNullOrEmtpy..
        //return Result.Failure<Subscriber>($"")
        Subscriber subscriber = new(
            id, personId, subscriberNumber, contractNumber, 
            dateOfContractConclusion, ContractType, 
            reasonForTerminationOfContract, personalBill, services, 
            dateOfTerminationOfTheContract, serialNumberOfEquipment);

        return Result.Success(subscriber);
    }
}
