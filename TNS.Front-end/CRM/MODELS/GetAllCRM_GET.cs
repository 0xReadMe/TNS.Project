using System.Text.Json;
using System.Text.Json.Serialization;

namespace TNS.Front_end.CRM.MODELS
{
    public class GetAllCRM_GET
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("subscriberId")]
        public string SubscriberId { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("closingDate")]
        public DateTime ClosingDate { get; set; }

        [JsonPropertyName("serviceId")]
        public string ServiceId { get; set; }

        [JsonPropertyName("serviceProvidedId")]
        public string ServiceProvidedId { get; set; }

        [JsonPropertyName("serviceTypeId")]
        public string ServiceTypeId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("typeOfProblem")]
        public string TypeOfProblem { get; set; }

        [JsonPropertyName("problemDescription")]
        public string ProblemDescription { get; set; }
    }
}
