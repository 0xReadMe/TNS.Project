namespace TNS.API.CONTRACTS.SUBSCRIBERS;

public record EditSubscriber_PUT
(
    bool ContractType,
    string ReasonForTerminationOfContract,
    uint PersonalBill,
    string Services,
    DateOnly DateOfContractConclusion,
    DateOnly DateOfTerminationOfTheContract,
    string TypeOfEquipment,
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
     

