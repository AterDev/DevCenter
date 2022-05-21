namespace Share.Models.Webhook.GitLab;

public class PipelineInfo
{
    public string? ProjectName { get; set; }
    public string? CommitContent { get; set; }
    public string? CommitUserName { get; set; }
    public string? Url { get; set; }
    public long? Duration { get; set; }
    public DateTimeOffset? FinishTime { get; set; }
    public string? Status { get; set; }
}
