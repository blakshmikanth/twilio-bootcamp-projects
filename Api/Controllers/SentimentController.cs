using System;
using Api.Filters;
using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.AspNet.Common;
using Microsoft.Extensions.Logging;
using Twilio.TwiML;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentController: TwilioController
    {
        private readonly ILogger<SentimentController> _logger;
        private readonly TextAnalyticsClient _client;
        private readonly AzureKeyCredential _credentials = new AzureKeyCredential("aeb6efc341444e3f96e6cecaf8c3ed17");
        private readonly Uri _endpoint = new Uri("https://twilio-demo-01.cognitiveservices.azure.com/");
        
        public SentimentController(ILogger<SentimentController> logger)
        {
            _logger = logger;
            _client = new TextAnalyticsClient(_endpoint, _credentials);
        }

        [HttpGet("validate")]
        [HttpPost("validate")]
        [ServiceFilter(typeof(Api.Filters.ValidateTwilioRequestAttribute))]
        public IActionResult Validate([FromForm] SmsRequest request)
        {
            return Ok("Success");
        }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok(DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss.fff"));
        }
        

        [HttpPost]
        [HttpGet]
        [ServiceFilter(typeof(Api.Filters.ValidateTwilioRequestAttribute))]
        public IActionResult Index([FromForm]SmsRequest request)
        {
            var response = new MessagingResponse();
            // string inputText = "I had the best day of my life. I wish you were there with me.";
            DocumentSentiment documentSentiment = _client.AnalyzeSentiment(request.Body);
            // Console.WriteLine($"Document sentiment: {documentSentiment.Sentiment}\n");
            // response.Message($"Sentiment: {documentSentiment.Sentiment}");

            switch (documentSentiment.Sentiment)
            {
                case TextSentiment.Positive:
                    response.Message("Thanks for your feedback.Here is your promo code: XYZ");
                    break;
                case TextSentiment.Negative:
                    response.Message("Thanks for your feedback.One of your agents will call you shortly");
                    break;
                default:
                    response.Message("Thanks for your feedback.We extended your subscription by 1 month - free");
                    break;
            }
            
            return TwiML(response);
        }
        
    }
}