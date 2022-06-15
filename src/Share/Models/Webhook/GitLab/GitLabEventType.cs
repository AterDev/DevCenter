namespace Share.Models.Webhook.GitLab;
/// <summary>
/// gitlab 事件类型
/// </summary>
public static class GitLabEventType
{
    /// <summary>
    /// 流水线
    /// </summary>
    public const string Pipeline = "Pipeline Hook";
    /// <summary>
    /// 议题
    /// </summary>
    public const string Issue = "Issue Hook";
    /// <summary>
    /// 评论
    /// </summary>
    public const string Note = "Note Hook";
    /// <summary>
    /// tag 推送
    /// </summary>
    public const string TagPush = "Tag Push Hook";
}

public static class GitLabHeader
{
    public const string Event = "X-Gitlab-Event";
    public const string Token = "X-Gitlab-Token";
}
