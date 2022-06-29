namespace Share.Options
{

    //public record DingTalkOptions(string Name, string NotifyUrl, string Secret);
    public class WebhookOptions
    {
        public List<DingTalkOptions>? DingTalk { get; set; }
    }

    public class DingTalkOptions
    {
        public string Name { get; set; } = string.Empty;
        public string? NotifyUrl { get; set; }
        public string? Secret { get; set; }
    }
}
