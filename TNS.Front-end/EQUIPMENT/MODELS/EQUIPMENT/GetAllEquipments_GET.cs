using System.Text.Json.Serialization;

namespace TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT
{
    public class GetAllEquipments_GET 
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("frequency")]
        public double Frequency { get; set; }

        [JsonPropertyName("attenuationCoefficient")]
        public string AttenuationCoefficient { get; set; }

        [JsonPropertyName("dtt")]
        public string DTT { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("isWorking")]
        public bool IsWorking { get; set; }
    };
}
