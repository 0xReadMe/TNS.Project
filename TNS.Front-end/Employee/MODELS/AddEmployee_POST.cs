using System.Text.Json.Serialization;

namespace TNS.Front_end.Employee.MODELS;

public class AddEmployee_POST
{
    [JsonPropertyName("roleId")]
    public int RoleId { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("photoId")]
    public string PhotoId { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public string DateOfBirth { get; set; }

    [JsonPropertyName("telegram")]
    public string Telegram { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }
};