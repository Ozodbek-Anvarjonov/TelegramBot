using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.Services;

namespace TelegramBot.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TelegramController(IMessageSenderService messageSenderService) : ControllerBase
{
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] string phoneNumber)
    {
        // https://t.me/grouhuzb
        // https://t.me/netCode_bot
        var result = await messageSenderService.SendAsync(phoneNumber, HttpContext.RequestAborted);
        
        return Ok(result);
    }
}