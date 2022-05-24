using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("weather")]
        public ICollection<Weather> Weather { get; set; }
        
        /// <summary>
        /// Internal parameter
        /// </summary>
        [JsonPropertyName("base")] 
        public string Base { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        /// <summary>
        /// Visibility, meter. The maximum value of the visibility is 10km
        /// </summary>
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }

        [JsonPropertyName("snow")]
        public Snow Snow { get; set; }

        /// <summary>
        /// Time of data calculation, unix, UTC
        /// </summary>
        [JsonPropertyName("dt")]
        public long Timestamp { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }
        
        /// <summary>
        /// Shift in seconds from UTC
        /// </summary>
        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        /// <summary>
        /// City ID
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Internal Parameter
        /// </summary>
        [JsonPropertyName("cod")]
        public int Cod { get; set; }
        
       
    }
}