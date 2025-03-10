using System.Text.Json.Serialization;

namespace PicPaySimplificado.Core.Responses;

public class NotifyErrorResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set;}
}
