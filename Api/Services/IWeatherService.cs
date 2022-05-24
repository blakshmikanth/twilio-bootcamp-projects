using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Api.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// To get current weather for the provided city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns><see cref="WeatherResponse"/></returns>
        Task<WeatherResponse> GetCurrent(string city);
    }

    public class WeatherService: IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;
        private readonly IConfiguration _configuration;

        public WeatherService(ILogger<WeatherService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        
        public async Task<WeatherResponse> GetCurrent(string city)
        {
            var baseUrl = _configuration.GetValue<string>("OpenWeather:Url");
            var apiKey = _configuration.GetValue<string>("OpenWeather:Key");
            
            var client = new RestClient(baseUrl);
            var request = new RestRequest()
                .AddQueryParameter("q", city)
                .AddQueryParameter("appid", apiKey)
                .AddQueryParameter("units", "metric");

            var response = await client.GetAsync<WeatherResponse>(request, new CancellationToken());

            return response;
        }
    }
    
}