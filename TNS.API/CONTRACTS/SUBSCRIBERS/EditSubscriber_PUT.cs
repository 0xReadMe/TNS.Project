using TNS.CORE.MODELS;
using TNS.CORE.VO;

namespace TNS.API.CONTRACTS.SUBSCRIBERS;

public record EditSubscriber_PUT
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
    PhoneNumber PhoneNumber,
    Email Email,
    Passport Passport
);
     

