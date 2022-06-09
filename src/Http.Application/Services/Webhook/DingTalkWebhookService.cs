using Microsoft.Extensions.Configuration;

using Share.Models.Webhook;
using Share.Models.Webhook.DingTalk;
using Share.Models.Webhook.GitLab;

using System.Net.Http.Json;

using Environment = System.Environment;

namespace Http.Application.Services.Webhook
{
    public class DingTalkWebhookService
    {
        private readonly IConfiguration _config;
        private static HttpClient HttpClient = new();

        public string Secret { get; set; }
        public string Url { get; set; }
        public DingTalkWebhookService(
            IConfiguration configuration)
        {
            _config = configuration;
            Url = _config.GetSection("Webhook")["DingTalk:NotifyUrl"];
            Secret = _config.GetSection("Webhook")["DingTalk:Secret"];
            HttpClient.Timeout = TimeSpan.FromSeconds(5);
        }

        public void SetSecretAndUrl(string url, string secret)
        {
            Url = url;
            Secret = secret;
        }
        public void SetDefault()
        {
            Url = _config.GetSection("Webhook")["DingTalk:NotifyUrl"];
            Secret = _config.GetSection("Webhook")["DingTalk:Secret"];
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

        public async Task SendExceptionNotifyAsync(ErrorLoggingRequest request)
        {
            var title = "❗异常:" + request.ProjectName + request.FilterName;
            var content = $"## {title}" + Environment.NewLine;
            AppendListItem(ref content, "服务名", request.ServiceName);
            AppendListItem(ref content, "路由", request.Route);
            AppendListItem(ref content, "请求体", request.RequestBody);
            AppendListItem(ref content, "请求参数", request.QueryString);
            AppendListItem(ref content, "TraceId", request.TraceId);
            content += "- 错误详情：" + Environment.NewLine
                + "```text" + Environment.NewLine
                + request.ErrorDetail + Environment.NewLine + "```" + Environment.NewLine;

            var msg = new MarkdownMessage
            {
                MarkdownText = new MarkdownText(title, content)
            };
            await PostNotifyAsync(msg);
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
