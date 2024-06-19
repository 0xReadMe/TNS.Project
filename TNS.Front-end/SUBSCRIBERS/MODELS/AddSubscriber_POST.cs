using System.Text.Json.Serialization;

namespace TNS.Front_end.SUBSCRIBERS.MODELS;

public class AddSubscriber_POST
{
    [JsonPropertyName("contractType")]
    public bool ContractType { get; set; }

    [JsonPropertyName("reasonForTerminationOfContract")]
    public string ReasonForTerminationOfContract { get; set; }

    [JsonPropertyName("personalBill")]
    public uint PersonalBill { get; set; }

    [JsonPropertyName("services")]
    public string Services { get; set; }

    [JsonPropertyName("dateOfContractConclusion")]
    public DateOnly DateOfContractConclusion { get; set; }

    [JsonPropertyName("dateOfTerminationOfTheContract")]
    public DateOnly DateOfTerminationOfTheContract { get; set; }

    [JsonPropertyName("typeOfEquipment")]
    public string TypeOfEquipment { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("middleName")]
    public string MiddleName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("dob")]
    public DateOnly DOB { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("divisionCode")]
    public string DivisionCode { get; set; }

    [JsonPropertyName("issuedBy")]
    public string IssuedBy { get; set; }

    [JsonPropertyName("series")]
    public int Series { get; set; }

    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("residenceAddress")]
    public string ResidenceAddress { get; set; }

    [JsonPropertyName("residentialAddress")]
    public string ResidentialAddress { get; set; }

    [JsonPropertyName("dateOfIssueOfPassport")]
    public DateOnly DateOfIssueOfPassport { get; set; }
};
