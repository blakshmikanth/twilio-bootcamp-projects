using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Api.Models
{
    public class Coordinates
    {
        [JsonPropertyName("lon")]
        public float Longitude { get; set; }
        
        [JsonPropertyName("lat")]
        public float Latitude { get; set; }
    }
}