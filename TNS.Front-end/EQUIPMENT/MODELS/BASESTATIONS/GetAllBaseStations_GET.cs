using System.Text.Json.Serialization;

namespace TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS
{
    public class GetAllBaseStations_GET
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("addressId")]
        public Guid AddressId { get; set; }

        [JsonPropertyName("baseStationName")]
        public string BaseStationName { get; set; }

        [JsonPropertyName("s")]
        public double S { get; set; }

        [JsonPropertyName("frequency")]
        public int Frequency { get; set; }

        [JsonPropertyName("typeAntenna")]
        public string TypeAntenna { get; set; }

        [JsonPropertyName("handover")]
        public int Handover { get; set; }

        [JsonPropertyName("communicationProtocol")]
        public string CommunicationProtocol { get; set; }

        [JsonPropertyName("isWorking")]
        public bool IsWorking { get; set; }
    }
}
