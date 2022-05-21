using Microsoft.Extensions.Configuration;
using Share.Models.Webhook.DingTalk;
using Share.Models.Webhook.GitLab;
using System.Net.Http.Json;

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

        public void SendPipelineNotify(PipelineInfo? pipelineInfo)
        {
            if (pipelineInfo != null)
            {

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
                Status = "成功"
            };
            var content = "- 提交人:" + pipeLineInfo.CommitUserName;
            content += "- 提交内容:" + pipeLineInfo.CommitContent;
            content += "- 完成时间:" + pipeLineInfo.FinishTime?.ToString("yyyy-MM-dd HH:mm:ss");
            content += "- 耗时:*" + pipeLineInfo.Duration + "*秒";
            content += $@"[查看详情]({pipeLineInfo.Url})";
            var title = pipeLineInfo.ProjectName + " 构建" + pipeLineInfo.Status;
            var msg = new MarkdownMessage
            {
                MarkdownText = new MarkdownText(title, content)
            };
            await PostNotifyAsync(msg);

        }

        protected async Task PostNotifyAsync(object data)
        {
            var content = JsonContent.Create(data);
            var response = await HttpClient.PostAsync(Url, content);
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync();
            }
        }
    }

}
