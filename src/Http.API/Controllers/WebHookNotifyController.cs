using System.Text.Json;
using Application.Services.Webhook;
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
    /// <param name="subscriber"></param>
    /// <returns></returns>
    [HttpPost("gitlab/{subscriber}")]
    public async Task<ActionResult> GitLabNotifyAsync([FromRoute] string subscriber, [FromBody] JsonElement request)
    {
        if (Request.Headers.TryGetValue(GitLabHeader.Token, out StringValues secret))
        {
            // secret 配置及验证
            if (secret.FirstOrDefault()!.Equals("genars.gitlab"))
            {
                if (Request.Headers.TryGetValue(GitLabHeader.Event, out StringValues events))
                {
                    string? eventType = events.FirstOrDefault();
                    _webhookService.SetConfig(subscriber.Trim());
                    await HookHandlerAsync(eventType!, request);
                    return Ok();
                }
                return Forbid("wrong header");
            }
            else
            {
                return Forbid("wrong header");
            }
        }
        return Forbid();
    }

    private async Task HookHandlerAsync(string eventType, JsonElement request)
    {
        switch (eventType)
        {
            case GitLabEventType.Pipeline:
                PipelineInfo? pipeline = GitLabWebhookService.GetPipeLineInfo(request.Deserialize<PipelineRequest>()!);

                await _webhookService.SendPipelineNotifyAsync(pipeline);
                break;

            case GitLabEventType.Issue:
                IssueInfo? issue = GitLabWebhookService.GetIssueInfo(request.Deserialize<IssueRequest>()!);
                await _webhookService.SendIssueNotifyAsync(issue);
                break;
            case GitLabEventType.Note:

                NoteInfo? note = GitLabWebhookService.GetNoteInfo(request.Deserialize<NoteRequest>()!);
                await _webhookService.SendNoteAsync(note);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 错误信息
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("exception")]
    public async Task<ActionResult> ErrorNotifyAsync([FromBody] ErrorLoggingRequest request)
    {
        _webhookService.SetConfig("Error");
        await _webhookService.SendExceptionNotifyAsync(request);
        return Ok();
    }
}
