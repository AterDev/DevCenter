using Http.Application.Services.Webhook;
namespace Http.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebHookNotifyController : ControllerBase
{
    private readonly DingTalkWebhookService _webhookService;
    public WebHookNotifyController(
        DingTalkWebhookService webhookService)
    {
        _webhookService = webhookService;
    }


    [HttpGet]
    public async Task<ActionResult> TestAsync()
    {
        await _webhookService.TestAsync();
        return Ok();
    }

}
