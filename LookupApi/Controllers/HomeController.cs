using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LookupApi.Models;
using Twilio;
using Twilio.Rest.Lookups.V1;

namespace LookupApi.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index([FromForm] string phoneNumber)
    {
        ViewBag.phoneNumber = phoneNumber;
        
        TwilioClient.Init(_configuration.GetValue<string>("Twilio:AccountSid"), 
            _configuration.GetValue<string>("Twilio:AuthToken"));
        
        var response = PhoneNumberResource.Fetch(countryCode: "GB",
            pathPhoneNumber: new Twilio.Types.PhoneNumber(phoneNumber));

        ViewBag.response = response;
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}