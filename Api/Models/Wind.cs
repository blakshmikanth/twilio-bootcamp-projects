using System.Text.Json.Serialization;

namespace Api.Models
{
    public class Wind
    {
        [JsonPropertyName("wind")]
        public decimal Speed { get; set; }
        
        [JsonPropertyName("deg")]
        public decimal Degree { get; set; }
    }
}