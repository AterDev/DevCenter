using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using Share.Models.Webhook;
using Share.Models.Webhook.DingTalk;
using Share.Models.Webhook.GitLab;
using Share.Options;

using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;

using Environment = System.Environment;

namespace Http.Application.Services.Webhook
{


    public class DingTalkWebhookService
    {
        private readonly IConfiguration _config;
        private static HttpClient HttpClient = new();
        private readonly List<DingTalkOptions> dingTalkOptions;

        public string Secret { get; set; }
        public string Url { get; set; }
        public DingTalkWebhookService(
            IConfiguration configuration,
            IOptions<WebhookOptions> options)
        {
            _config = configuration;
            dingTalkOptions = options.Value.DingTalk;

            Url = GetOption("GeneRoom")?.NotifyUrl ?? "";
            Secret = GetOption("GeneRoom")?.Secret ?? "";
            HttpClient.Timeout = TimeSpan.FromSeconds(5);
        }

        private DingTalkOptions? GetOption(string name)
        {
            return dingTalkOptions.Where(o => o.Name.Equals(name)).FirstOrDefault();
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

        public async Task SendPipelineNotifyAsync(PipelineInfo? pipelineInfo)
        {
            if (pipelineInfo != null)
            {
                var title = pipelineInfo.GetTitle();
                var content = $"## {title}" + Environment.NewLine;
                content += "- 提交人: " + pipelineInfo.CommitUserName + Environment.NewLine;
                content += "- 提交内容: " + pipelineInfo.CommitContent + Environment.NewLine;
                content += "- 提交时间: " + pipelineInfo.FinishTime?.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine;
                content += "- 耗时: **" + pipelineInfo.Duration + "**秒" + Environment.NewLine;
                content += $@"## [查看详情]({pipelineInfo.Url})" + Environment.NewLine;
                var msg = new MarkdownMessage
                {
                    MarkdownText = new MarkdownText(title, content)
                };
                await PostNotifyAsync(msg);
            }
        }
        public async Task SendIssueNotifyAsync(IssueInfo? issueInfo)
        {
            if (issueInfo != null)
            {
                var action = issueInfo.Action switch
                {
                    "open" => "👀新任务: ",
                    "close" => "👍关闭任务: ",
                    _ => "任务:"
                };
                var title = action + issueInfo.Title;
                var content = $"## {title}" + Environment.NewLine;
                AppendListItem(ref content, "### 分配给", issueInfo.UserName);
                content += "概要: " + Environment.NewLine
                    + issueInfo.Content
                    + Environment.NewLine + Environment.NewLine;
                content += "标签: **" + issueInfo.Tags + "**" + Environment.NewLine;
                content += $@"## [查看详情]({issueInfo.Url})" + Environment.NewLine;
                var msg = new MarkdownMessage
                {
                    MarkdownText = new MarkdownText(title, content)
                };
                await PostNotifyAsync(msg);
            }
        }
        public async Task SendExceptionNotifyAsync(ErrorLoggingRequest request)
        {
            // 本地开发环境不发通知
            if (request.Environment.ToLower().Equals("development"))
            {
                return;
            }
            var title = "❗异常:" + request.ProjectName + request.FilterName;
            var content = $"## {title}" + Environment.NewLine;
            AppendListItem(ref content, "服务名", request.ServiceName);
            AppendListItem(ref content, "请求路由", request.Route);
            AppendListItem(ref content, "请求体", request.RequestBody);
            AppendListItem(ref content, "请求参数", request.QueryString);
            AppendListItem(ref content, "TraceId", request.TraceId);
            content += "- 错误详情：" + Environment.NewLine
                + "> " + Environment.NewLine
                + FormatStackTrace(request.ErrorDetail) + Environment.NewLine;

            // 详情跳转页面
            content += $"### [查看详情]({request.TraceId})";

            var msg = new MarkdownMessage
            {
                MarkdownText = new MarkdownText(title, content)
            };
            await PostNotifyAsync(msg);
        }

        public string FormatStackTrace(string content)
        {
            var lines = content.Split("\n");
            content = "";
            foreach (var line in lines)
            {
                if (line.Contains(":line"))
                {
                    content += line + Environment.NewLine;
                }
            }
            return content;
        }

        private void AppendListItem(ref string content, string prefix, string? append)
        {
            if (!string.IsNullOrEmpty(append))
            {
                content += $"- {prefix}: {append}" + Environment.NewLine;
            }
        }
        public async Task TestAsync()
        {
            var pipeLineInfo = new PipelineInfo
            {
                CommitContent = "commit content",
                Duration = 22,
                CommitUserName = "niltor",
                ProjectName = "项目名称",
                Url = "http://219.147.85.131:9080/testing-room/admin",
                FinishTime = DateTime.Now,
                Status = "success"
            };
            var title = pipeLineInfo.GetTitle();
            var content = $"## {title}" + Environment.NewLine;
            content += "- 提交人: " + pipeLineInfo.CommitUserName + Environment.NewLine;
            content += "- 提交内容: " + pipeLineInfo.CommitContent + Environment.NewLine;
            content += "- 完成时间: " + pipeLineInfo.FinishTime?.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine;
            content += "- 耗时: **" + pipeLineInfo.Duration + "**秒" + Environment.NewLine;
            content += $@"## [查看详情]({pipeLineInfo.Url})" + Environment.NewLine;
            var msg = new MarkdownMessage
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
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var sign = HashCrypto.HMACSHA256(Secret, timestamp.ToString() + "\n" + Secret);
            sign = WebUtility.UrlEncode(sign);
            var content = JsonContent.Create(data);
            Url += $"&timestamp={timestamp}&sign={sign}";

            var response = await HttpClient.PostAsync(Url, content);
            if (response.IsSuccessStatusCode)
            {
                _ = await response.Content.ReadAsStringAsync();
                // TODO: 结果处理
                // {"errcode":0,"errmsg":"ok"}
            }
        }


    }

}
