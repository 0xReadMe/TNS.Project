namespace TNS.API.CONTRACTS.SUBSCRIBERS;

public record AddSubscriber_POST
(
    Guid SubscriberId,
    string SubscriberNumber,
    string ContractNumber,
    bool ContractType,
    string ReasonForTerminationOfContract,
    uint PersonalBill,
    string Services,
    DateOnly DateOfContractConclusion,
    DateOnly DateOfTerminationOfTheContract,
    string TypeOfEquipment,
    Guid PersonId,
    string FirstName,
    string MiddleName,
    string LastName,
    char Gender,
    DateOnly DOB,
    string PhoneNumber,
    string Email,
    string DivisionCode,
    string IssuedBy,
    int Series,
    int Number,
    string ResidenceAddress,
    string ResidentialAddress,
    DateOnly DateOfIssueOfPassport
);
