using System;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController: TwilioController
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IWeatherService _weatherService;

        public MessageController(ILogger<MessageController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = new MessagingResponse();
            response.Message("Hello world");
            return TwiML(response);
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromForm]SmsRequest request)
        {

            var response = new MessagingResponse();

            try
            {
                // Get city from the message body
                var city = request.Body;

                if (string.IsNullOrEmpty(city))
                {
                    response.Message("City name is required. Ex. London");
                    return TwiML(response);
                }
            
                // City name found.
                var apiResponse = await _weatherService.GetCurrent(city);
                var responseString = JsonSerializer.Serialize(apiResponse);
                _logger.LogInformation("Api response - {ResponseString}", responseString);

            
                response.Message($"{city} - Current Temp - {apiResponse.Main.Temperature}c");
                return TwiML(response);

            }
            catch (Exception e)
            {
                _logger.LogError("Unexpected error: {ErrorMessage}",e.Message );
                response.Message("Unexpected error. Check city name and try again");
                return TwiML(response);
            }
            
        }

    }
}