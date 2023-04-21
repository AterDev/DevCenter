using System.Net;
using System.Net.Http.Json;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using Share.Models.Webhook;
using Share.Models.Webhook.DingTalk;
using Share.Models.Webhook.GitLab;
using Share.Options;

namespace Application.Services.Webhook;

public class DingTalkWebhookService
{
    private readonly IConfiguration _config;
    private static readonly HttpClient HttpClient = new();
    private readonly List<DingTalkOptions> dingTalkOptions;

    public string Secret { get; set; }
    public string Url { get; set; }
    public DingTalkWebhookService(
        IConfiguration configuration,
        IOptions<WebhookOptions> options)
    {
        _config = configuration;
        dingTalkOptions = options.Value.DingTalk!;

        Url = GetOption("GeneRoom")?.NotifyUrl ?? "";
        Secret = GetOption("GeneRoom")?.Secret ?? "";
        HttpClient.Timeout = TimeSpan.FromSeconds(5);
    }

    private DingTalkOptions? GetOption(string name)
    {
        return dingTalkOptions.Where(o => o.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
    }

    /// <summary>
    /// 手动设置消息链接
    /// </summary>
    /// <param name="url"></param>
    /// <param name="secret"></param>
    public void SetSecretAndUrl(string url, string secret)
    {
        Url = url;
        Secret = secret;
    }

    /// <summary>
    /// 从配置中设置不同的消息链接
    /// </summary>
    public void SetConfig(string name)
    {
        Url = GetOption(name)?.NotifyUrl ?? "";
        Secret = GetOption(name)?.Secret ?? "";
    }

    public void SetDefault()
    {
        Url = GetOption("GeneRoom")?.NotifyUrl ?? "";
        Secret = GetOption("GeneRoom")?.Secret ?? "";
    }
    /// <summary>
    /// 流水线管道通知
    /// </summary>
    /// <param name="pipelineInfo"></param>
    /// <returns></returns>
    public async Task SendPipelineNotifyAsync(PipelineInfo? pipelineInfo)
    {
        if (pipelineInfo != null)
        {
            string title = pipelineInfo.GetTitle();
            string content = $"## {title}" + System.Environment.NewLine;
            content += "- 提交人: " + pipelineInfo.CommitUserName + System.Environment.NewLine;
            content += "- 提交内容: " + pipelineInfo.CommitContent + System.Environment.NewLine;
            content += "- 提交时间: " + pipelineInfo.FinishTime?.ToString("yyyy-MM-dd HH:mm:ss") + System.Environment.NewLine;
            content += "- 流水线:" + System.Environment.NewLine + pipelineInfo.Job + System.Environment.NewLine;
            content += "- 耗时: **" + pipelineInfo.Duration + "**秒" + System.Environment.NewLine;
            content += $@"## [查看详情]({pipelineInfo.Url})" + System.Environment.NewLine;
            MarkdownMessage msg = new()
            {
                MarkdownText = new MarkdownText(title, content)
            };
            await PostNotifyAsync(msg);
        }
    }
    /// <summary>
    /// Issue通知
    /// </summary>
    /// <param name="issueInfo"></param>
    /// <returns></returns>
    public async Task SendIssueNotifyAsync(IssueInfo? issueInfo)
    {
        if (issueInfo != null)
        {
            string action = issueInfo.Action switch
            {
                "open" => "👀新任务: ",
                "close" => "👍关闭任务: ",
                _ => "任务:"
            };
            string title = action + issueInfo.Title;
            string content = $"## {title}" + System.Environment.NewLine;
            AppendListItem(ref content, "### 分配给", issueInfo.UserName);
            content += "概要: " + System.Environment.NewLine
                + issueInfo.Content
                + System.Environment.NewLine + System.Environment.NewLine;
            content += "标签: **" + issueInfo.Tags + "**" + System.Environment.NewLine;
            content += $@"## [查看详情]({issueInfo.Url})" + System.Environment.NewLine;
            MarkdownMessage msg = new()
            {
                MarkdownText = new MarkdownText(title, content)
            };
            await PostNotifyAsync(msg);
        }
    }

    /// <summary>
    /// 异常错误通知
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task SendExceptionNotifyAsync(ErrorLoggingRequest request)
    {
        // 本地开发环境不发通知
        if (request.Environment.ToLower().Equals("development"))
        {
            return;
        }
        string title = "❗异常:" + request.ProjectName + request.FilterName;
        string content = $"## {title}" + System.Environment.NewLine;
        AppendListItem(ref content, "服务名", request.ServiceName);
        AppendListItem(ref content, "请求路由", request.Route);
        AppendListItem(ref content, "请求体", request.RequestBody);
        AppendListItem(ref content, "请求参数", request.QueryString);
        AppendListItem(ref content, "TraceId", request.TraceId);
        content += "- 错误详情：" + System.Environment.NewLine
            + "> " + System.Environment.NewLine
            + FormatStackTrace(request.ErrorDetail) + System.Environment.NewLine;

        // 详情跳转页面
        content += $"### [查看详情]({request.TraceId})";

        MarkdownMessage msg = new()
        {
            MarkdownText = new MarkdownText(title, content)
        };
        await PostNotifyAsync(msg);
    }

    /// <summary>
    /// 发送提醒
    /// </summary>
    /// <param name="fromUser"></param>
    /// <param name="toUser"></param>
    public async Task SendNoteAsync(NoteInfo? note)
    {
        if (note == null)
        {
            return;
        }

        List<string>? toUser = note.ToUser;
        if (toUser != null && toUser.Any())
        {
            List<string> atMobiles = new();
            Gitlab2DingTalkUserMap userMap = Gitlab2DingTalkUserMap.GetUsersMap();
            if (toUser.Any())
            {
                toUser.ForEach(u =>
                {
                    string? mobile = userMap.GetValueOrDefault(u);
                    // 替换原内容@
                    note.Content = note.Content.Replace(u, mobile);

                    // 构造提醒列表
                    if (mobile != null)
                    {
                        atMobiles.Add(mobile);
                    }
                });
            }

            string title = $"来自{note.FromUser}的评论";
            string mdcontent = $"## 新评论提醒：{System.Environment.NewLine}";
            AppendListItem(ref mdcontent, "来自", note.FromUser);
            AppendListItem(ref mdcontent, "项目", note.Project);
            AppendListItem(ref mdcontent, "内容", note.Content);
            mdcontent += $@"## [查看详情]({note.Url})" + System.Environment.NewLine;


            MarkdownMessage msg = new()
            {
                MarkdownText = new MarkdownText(title, mdcontent),
                At = new MessageAt
                {
                    AtMobiles = atMobiles
                }
            };

            await PostNotifyAsync(msg);
        }
    }
    /// <summary>
    /// 格式化异常stacktrace内容
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public string FormatStackTrace(string content)
    {
        string[] lines = content.Split("\n");
        content = "";
        foreach (string line in lines)
        {
            if (line.Contains(":line"))
            {
                content += line + System.Environment.NewLine;
            }
        }
        return content;
    }

    private void AppendListItem(ref string content, string prefix, string? append)
    {
        if (!string.IsNullOrEmpty(append))
        {
            content += $"- {prefix}: {append}" + System.Environment.NewLine;
        }
    }
    public async Task TestAsync()
    {
        PipelineInfo pipeLineInfo = new()
        {
            CommitContent = "commit content",
            Duration = 22,
            CommitUserName = "niltor",
            ProjectName = "项目名称",
            Url = "http://219.147.85.131:9080/testing-room/admin",
            FinishTime = DateTime.Now,
            Status = "success"
        };
        string title = pipeLineInfo.GetTitle();
        string content = $"## {title}" + System.Environment.NewLine;
        content += "- 提交人: " + pipeLineInfo.CommitUserName + System.Environment.NewLine;
        content += "- 提交内容: " + pipeLineInfo.CommitContent + System.Environment.NewLine;
        content += "- 完成时间: " + pipeLineInfo.FinishTime?.ToString("yyyy-MM-dd HH:mm:ss") + System.Environment.NewLine;
        content += "- 耗时: **" + pipeLineInfo.Duration + "**秒" + System.Environment.NewLine;
        content += $@"## [查看详情]({pipeLineInfo.Url})" + System.Environment.NewLine;
        MarkdownMessage msg = new()
        {
            MarkdownText = new MarkdownText(title, content)
        };
        await PostNotifyAsync(msg);

    }

    /// <summary>
    /// 发送通知
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    protected async Task PostNotifyAsync(object data)
    {
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        string sign = HashCrypto.HMACSHA256(Secret, timestamp.ToString() + "\n" + Secret);
        sign = WebUtility.UrlEncode(sign);
        JsonContent content = JsonContent.Create(data);
        Url += $"&timestamp={timestamp}&sign={sign}";

        HttpResponseMessage response = await HttpClient.PostAsync(Url, content);
        if (response.IsSuccessStatusCode)
        {
            _ = await response.Content.ReadAsStringAsync();
            // TODO: 结果处理
            // {"errcode":0,"errmsg":"ok"}
        }
    }


}

