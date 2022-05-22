using Http.Application.Services.Webhook;
using Microsoft.Extensions.Primitives;
using Share.Models.Webhook.GitLab;

namespace Http.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebHookNotifyController : ControllerBase
{
    private readonly DingTalkWebhookService _webhookService;
    private readonly GitLabWebhookService _gitLab;

    public WebHookNotifyController(
        DingTalkWebhookService webhookService,
        GitLabWebhookService gitLab)
    {
        _webhookService = webhookService;
        _gitLab = gitLab;
    }

    /// <summary>
    /// gitlab webhook 通知
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("gitlab")]
    public async Task<ActionResult> GitLabNotifyAsync([FromBody] PipelineRequest request)
    {
        if (Request.Headers.TryGetValue("X-Gitlab-Token", out StringValues secret))
        {
            // TODO: secret 配置及验证
            if (secret.FirstOrDefault()!.Equals("genars.gitlab"))
            {
                var req = _gitLab.GetPipeLineInfo(request);
                if (req == null) return Ok();
                await _webhookService.SendPipelineNotifyAsync(req);
                return Ok();
            }
        }
        return Forbid();
    }

}
