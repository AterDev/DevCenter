namespace Share.Models.Webhook.DingTalk;

public class MarkdownMessage : MessageBase
{
    [JsonPropertyName("markdown")]
    public MarkdownText? MarkdownText { get; set; }
    public override string MsgType { get; set; } = "markdown";
}

public class MarkdownText
{
    public MarkdownText(string title, string text)
    {
        Title = title;
        Text = text;
    }
    public string Title { get; set; }
    public string Text { get; set; }
}

