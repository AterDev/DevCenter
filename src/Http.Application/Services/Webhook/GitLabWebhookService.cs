﻿using Share.Models.Webhook.GitLab;

namespace Http.Application.Services.Webhook;

public class GitLabWebhookService
{
    public GitLabWebhookService()
    {
    }


    public PipelineInfo? GetPipeLineInfo(PipelineRequest request)
    {
        var status = request.ObjectAttributes?.Status;
        if (string.IsNullOrWhiteSpace(status)
            || status.Equals("pending")
            || status.Equals("running"))
        {
            return default;
        }
        return new PipelineInfo
        {
            CommitContent = request.Commit?.Title,
            CommitUserName = request.Commit?.Author?.Name,
            Duration = request.ObjectAttributes?.Duration,
            FinishTime = request.ObjectAttributes?.FinishedAt,
            ProjectName = request.Project?.Name,
            Url = request.Project?.WebUrl + "/-/pipelines/" + request.ObjectAttributes?.Id,
            Status = status
        };
    }

}
