using System.Text.Json.Serialization;

namespace Api.Models
{
    public class Rain
    {
        /// <summary>
        /// Snow volume for the last 1 hour, mm
        /// </summary>
        [JsonPropertyName("1h")]
        public float LastHour { get; set; }
        
        /// <summary>
        /// Rain volume for the last 3 hours, mm
        /// </summary>
        [JsonPropertyName("3h")]
        public float LastThreeHours { get; set; }
    }
}