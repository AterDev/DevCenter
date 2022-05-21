namespace Share.Models.Webhook.DingTalk;

public class MarkdownMessage : MessageBase
{
    [JsonPropertyName("markdown")]
    public MarkdownText? MarkdownText { get; set; }
    [JsonPropertyName("msgtype")]
    public override string MsgType { get; set; } = "markdown";
}

public class MarkdownText
{
    public MarkdownText(string title, string text)
    {
        Title = title;
        Text = text;
    }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
}

