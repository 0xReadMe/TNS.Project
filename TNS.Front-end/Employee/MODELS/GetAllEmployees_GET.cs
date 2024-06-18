using System.Text.Json.Serialization;

namespace TNS.Front_end.Employee.MODELS;

public class GetAllEmployees_GET
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("roleId")]
    public int RoleId { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("photoId")]
    public string PhotoId { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public DateOnly DateOfBirth { get; set; }

    [JsonPropertyName("telegram")]
    public string? Telegram { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; }

    [JsonPropertyName("passwordHash")]
    public string PasswordHash { get; set; }
}
