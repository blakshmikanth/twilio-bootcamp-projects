using System.Text.Json.Serialization;

namespace Api.Models
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public decimal All { get; set; }
    }
}