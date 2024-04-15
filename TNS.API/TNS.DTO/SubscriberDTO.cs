using System.ComponentModel.DataAnnotations;
using TNS.Database;

namespace TNS.API.TNS.DTO
{
    public record SubscriberDTO(
        [Required] string subscriberNumber,
        [Required] string contractNumber,
        [Required] DateOnly DateOfContractConclusion,
        [Required] bool ContractType,
        string ReasonForTerminationOfContract,
        [Required] uint PersonalBill,
        string Services,
        DateOnly DateOfTerminationOfTheContract,
        string SerialNumberOfEquipment
        );
}
