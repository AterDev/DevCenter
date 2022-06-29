namespace Share.Models.Webhook.GitLab;

public class NoteInfo
{
    public string FromUser { get; set; }
    public List<string>? ToUser { get; set; }
    public string Project { get; set; }
    public string Content { get; set; }
    public string? Url { get; set; }

    public NoteInfo(string fromUser, string project, string content)
    {
        FromUser = fromUser;
        Project = project;
        Content = content;
    }
}
