using LookupApi.Models;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Notify.V1.Service;

namespace LookupApi.Api;

[ApiController]
[Route("api/notify")]
public class NotifyController : Controller
{
    private readonly IConfiguration _configuration;

    public NotifyController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpPost("bind")]
    public IActionResult Bind([FromBody]BindingRequestModel model)
    {
        var accountSid = _configuration.GetValue<string>("Twilio:AccountSid");
        var authToken = _configuration.GetValue<string>("Twilio:AuthToken");
        var serviceSid = _configuration.GetValue<string>("Twilio:NotifyService");
        TwilioClient.Init(accountSid, authToken);

        var binding = BindingResource.Create(serviceSid, 
            "1", 
            BindingResource.BindingTypeEnum.Sms,
            model.PhoneNumber);

        return Ok(binding);
    }

    [HttpPost("send")]
    public IActionResult Send([FromBody] NotificationRequestModel model)
    {
        var accountSid = _configuration.GetValue<string>("Twilio:AccountSid");
        var authToken = _configuration.GetValue<string>("Twilio:AuthToken");
        var serviceSid = _configuration.GetValue<string>("Twilio:NotifyService");
        TwilioClient.Init(accountSid, authToken);

        var notification = NotificationResource.Create(serviceSid,
            identity: model.Identifiers,
            body: model.Message
        );
        
        return Ok(notification);
    }

}