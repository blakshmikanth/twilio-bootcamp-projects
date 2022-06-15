using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Notify.V1.Service;

namespace LookupApi.Controllers;

public class NotifyController : Controller
{
    private readonly IConfiguration _configuration;

    public NotifyController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    
    
}