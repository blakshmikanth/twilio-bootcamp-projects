using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace LookupApi.Models;

public class BindingRequestModel
{
    [JsonPropertyName("phoneNumber")]
    [JsonProperty(PropertyName = "phoneNumber")]
    public string PhoneNumber { get; set; } = "";
}