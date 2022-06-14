using Http.Application.Services.Webhook;
using Microsoft.Extensions.Primitives;
using Share.Models.Webhook;
using Share.Models.Webhook.GitLab;

namespace Http.API.Controllers;

/// <summary>
/// WebHook Notify
/// </summary>
[Route("api/[controller]")]
[ApiController]
//[ApiExplorerSettings(IgnoreApi = true)]
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
            // secret 配置及验证
            if (secret.FirstOrDefault()!.Equals("genars.gitlab"))
            {
                var req = _gitLab.GetPipeLineInfo(request);
                if (req == null)
                {
                    return Ok("过滤掉正在运行的流水线");
                }
                _webhookService.SetDefault();
                await _webhookService.SendPipelineNotifyAsync(req);
                return Ok();
            }
            else
            {
                return Forbid("wrong header");
            }
        }
        return Forbid();
    }

    /// <summary>
    /// 错误信息
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("exception")]
    public async Task<ActionResult> ErrorNotifyAsync([FromBody] ErrorLoggingRequest request)
    {
        var secret = "SEC0a23c111ecd82915286c674ae4d392d1d58564caf81fc7dcf4ac58c3744ff4c1";
        var url = "https://oapi.dingtalk.com/robot/send?access_token=ec387e595b12ad632050bc56f672f79f34f626523d51ed812e2be18bb045717b";
        _webhookService.SetSecretAndUrl(url, secret);

        await _webhookService.SendExceptionNotifyAsync(request);
        return Ok();
    }
}
