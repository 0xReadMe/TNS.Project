using System.Text.Json.Serialization;

namespace TNS.API.CONTRACTS.CRM;

public record GetAllCRM_GET(
    Guid Id,
    string SubscriberNumber,
    uint PersonalBill,
    string TypeOfEquipmentDateTime,
    DateOnly CreationDateDateTime,
    DateOnly ClosingDate,
    string Service,
    string ServiceProvided,
    string ServiceType,
    string Status,
    string TypeOfProblem,
    string ProblemDescription 
);
