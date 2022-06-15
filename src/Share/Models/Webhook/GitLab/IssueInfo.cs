namespace Share.Models.Webhook.GitLab;
/// <summary>
/// 议题提示模型
/// </summary>
public class IssueInfo
{
    public IssueInfo(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public string? ProjectName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string? Url { get; set; }
    public string? Tags { get; set; }
    public string Action { get; set; } = string.Empty;
}

