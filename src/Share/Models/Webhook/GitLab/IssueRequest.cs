namespace Share.Models.Webhook.GitLab;

public partial class IssueRequest
{
    [JsonPropertyName("object_kind")]
    public string? ObjectKind { get; set; }

    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("user")]
    public User? User { get; set; }

    [JsonPropertyName("project")]
    public Project? Project { get; set; }

    [JsonPropertyName("object_attributes")]
    public ObjectAttributes ObjectAttributes { get; set; } = null!;

    [JsonPropertyName("labels")]
    public List<Label>? Labels { get; set; }

    [JsonPropertyName("changes")]
    public Changes? Changes { get; set; }

    [JsonPropertyName("repository")]
    public Repository? Repository { get; set; }

    [JsonPropertyName("assignees")]
    public List<User>? Assignees { get; set; }
}


public partial class Changes
{
    [JsonPropertyName("description")]
    public Description? Description { get; set; }

    [JsonPropertyName("last_edited_at")]
    public Description? LastEditedAt { get; set; }

    [JsonPropertyName("last_edited_by_id")]
    public TedById? LastEditedById { get; set; }

    [JsonPropertyName("updated_at")]
    public Description? UpdatedAt { get; set; }

    [JsonPropertyName("updated_by_id")]
    public TedById? UpdatedById { get; set; }
}

public class Description
{
    [JsonPropertyName("previous")]
    public string? Previous { get; set; }

    [JsonPropertyName("current")]
    public string? Current { get; set; }
}

public class TedById
{
    [JsonPropertyName("previous")]
    public string? Previous { get; set; }

    [JsonPropertyName("current")]
    public long Current { get; set; }
}

public partial class Label
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("project_id")]
    public long ProjectId { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("template")]
    public bool Template { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("group_id")]
    public long? GroupId { get; set; }
}

public partial class ObjectAttributes
{
    [JsonPropertyName("author_id")]
    public long AuthorId { get; set; }

    [JsonPropertyName("closed_at")]
    public string? ClosedAt { get; set; }

    [JsonPropertyName("confidential")]
    public bool Confidential { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("discussion_locked")]
    public string? DiscussionLocked { get; set; }

    [JsonPropertyName("due_date")]
    public string? DueDate { get; set; }


    [JsonPropertyName("iid")]
    public long? Iid { get; set; }

    [JsonPropertyName("last_edited_at")]
    public string? LastEditedAt { get; set; }

    [JsonPropertyName("last_edited_by_id")]
    public long? LastEditedById { get; set; }

    [JsonPropertyName("milestone_id")]
    public long? MilestoneId { get; set; }

    [JsonPropertyName("moved_to_id")]
    public long? MovedToId { get; set; }

    [JsonPropertyName("duplicated_to_id")]
    public long? DuplicatedToId { get; set; }

    [JsonPropertyName("project_id")]
    public long? ProjectId { get; set; }

    [JsonPropertyName("relative_position")]
    public long? RelativePosition { get; set; }

    [JsonPropertyName("state_id")]
    public long? StateId { get; set; }

    [JsonPropertyName("time_estimate")]
    public long? TimeEstimate { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("updated_by_id")]
    public long? UpdatedById { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("total_time_spent")]
    public long? TotalTimeSpent { get; set; }

    [JsonPropertyName("time_change")]
    public long? TimeChange { get; set; }

    [JsonPropertyName("human_total_time_spent")]
    public string? HumanTotalTimeSpent { get; set; }

    [JsonPropertyName("human_time_change")]
    public string? HumanTimeChange { get; set; }

    [JsonPropertyName("human_time_estimate")]
    public string? HumanTimeEstimate { get; set; }

    [JsonPropertyName("assignee_ids")]
    public List<long>? AssigneeIds { get; set; }

    [JsonPropertyName("assignee_id")]
    public long? AssigneeId { get; set; }

    [JsonPropertyName("labels")]
    public List<Label>? Labels { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }

    [JsonPropertyName("action")]
    public string? Action { get; set; }
}

public partial class Project
{
    [JsonPropertyName("homepage")]
    public Uri? Homepage { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("ssh_url")]
    public string? SshUrl { get; set; }

    [JsonPropertyName("http_url")]
    public Uri? HttpUrl { get; set; }
}

public class Repository
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("homepage")]
    public Uri? Homepage { get; set; }
}

