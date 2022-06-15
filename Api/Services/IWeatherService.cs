using System;
using System.Threading.Tasks;
using Api.Models;

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
}