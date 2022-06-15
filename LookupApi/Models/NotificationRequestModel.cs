using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace LookupApi.Models;

public class NotificationRequestModel
{
    [JsonProperty(PropertyName = "identifiers")]
    [JsonPropertyName("identifiers")]
    public List<string> Identifiers { get; set; } = new List<string>();

    [JsonProperty(PropertyName = "message")]
    [JsonPropertyName("message")]
    public string Message { get; set; } = "";
}