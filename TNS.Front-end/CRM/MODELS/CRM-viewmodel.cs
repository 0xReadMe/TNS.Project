using System.Text.Json.Serialization;

namespace TNS.Front_end.CRM.MODELS
{
    public class CRM_viewmodel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("subscriberNumber")]
        public string SubscriberNumber { get; set; }

        [JsonPropertyName("personalBill")]
        public uint PersonalBill { get; set; }

        [JsonPropertyName("typeOfEquipmentDateTime")]
        public string TypeOfEquipment { get; set; }

        [JsonPropertyName("creationDate")]
        public DateOnly CreationDate { get; set; }

        [JsonPropertyName("closingDate")]
        public DateOnly ClosingDate { get; set; }

        [JsonPropertyName("service")]
        public string Service { get; set; }

        [JsonPropertyName("serviceProvided")]
        public string ServiceProvided { get; set; }

        [JsonPropertyName("serviceType")]
        public string ServiceType { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("typeOfProblem")]
        public string TypeOfProblem { get; set; }

        [JsonPropertyName("problemDescription")]
        public string ProblemDescription { get; set; }
    }
}
