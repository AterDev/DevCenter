
using Share.Models.Webhook.GitLab;

namespace Http.Application.Services.Webhook;

public class GitLabWebhookService
{
    public GitLabWebhookService()
    {
    }

    public static PipelineInfo? GetPipeLineInfo(PipelineRequest request)
    {
        var status = request.ObjectAttributes?.Status;
        var jobs = request.Builds!.Where(b => b.Status == "success").Select(b => "- " + b.Name).ToList();
        var josString = string.Join(System.Environment.NewLine, jobs);
        return string.IsNullOrWhiteSpace(status)
            || status.Equals("pending")
            || status.Equals("running")
            || status.Equals("manual")
            ? default
            : new PipelineInfo
            {
                CommitContent = request.Commit?.Title,
                CommitUserName = request.Commit?.Author?.Name,
                Duration = request.ObjectAttributes?.Duration,
                FinishTime = request.Commit?.Timestamp,
                ProjectName = request.Project?.Name,
                Job = josString,
                Url = request.Project?.WebUrl + "/-/pipelines/" + request.ObjectAttributes?.Id,
                Status = status
            };
    }

    public static IssueInfo? GetIssueInfo(IssueRequest request)
    {
        // close,update,open
        var action = request.ObjectAttributes.Action ?? "";
        if (action.Equals("update"))
        {
            return default;
        }

        var content = request.ObjectAttributes.Description;
        if (content.Length > 50)
        {
            content = content[..50];
        }
        var tags = request.Labels?.Select(l => l.Title).ToList();
        return new IssueInfo(request.ObjectAttributes.Title, content)
        {
            ProjectName = request.Project?.Name,
            Url = request.ObjectAttributes.Url,
            Tags = tags != null ? string.Join(";", tags) : "",
            Action = action,
            UserName = request.Assignees?.FirstOrDefault()!.Name ?? ""
        };
    }

    public static NoteInfo? GetNoteInfo(NoteRequest request)
    {
        var noteableId = request.ObjectAttributes!.NoteableId;
        if (noteableId == null)
        {
            return default;
        }

        var content = request.ObjectAttributes.Note!;

        var noteUsers = content.Split(" ")
            .Where(s => s.StartsWith("@"))
            .Select(s => s.Replace("@", "")).ToList();


        if (content.Length > 100)
        {
            content = content[..100];
        }

        return new NoteInfo(request.User!.Username!, request.Project!.Name!, content)
        {
            Url = request.ObjectAttributes.Url,
            ToUser = noteUsers,
        };
    }
}
