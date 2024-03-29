﻿namespace Share.Models.Webhook.GitLab;

public class PipelineInfo
{
    public string? ProjectName { get; set; }
    public string? CommitContent { get; set; }
    public string? CommitUserName { get; set; }
    public string? Url { get; set; }
    public long? Duration { get; set; }
    public DateTimeOffset? FinishTime { get; set; }
    public string? Status { get; set; }
    public string? Job { get; set; }

    public string GetTitle()
    {
        string res = ProjectName + " 构建 ";
        return (Status is "success" or "scheduled") ? "👍 " + res + "成功" : "❗ " + res + Status;
    }
}
