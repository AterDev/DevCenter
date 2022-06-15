namespace Share.Models.Webhook.GitLab;

public partial class NoteRequest
{
    [JsonPropertyName("object_kind")]
    public string? ObjectKind { get; set; }

    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("user")]
    public User? User { get; set; }

    [JsonPropertyName("project_id")]
    public long ProjectId { get; set; }

    [JsonPropertyName("project")]
    public Project? Project { get; set; }

    [JsonPropertyName("object_attributes")]
    public ObjectAttributes? ObjectAttributes { get; set; }

    [JsonPropertyName("repository")]
    public Repository? Repository { get; set; }

    [JsonPropertyName("issue")]
    public Issue? Issue { get; set; }
}

public partial class Issue
{
    [JsonPropertyName("author_id")]
    public long AuthorId { get; set; }

    [JsonPropertyName("closed_at")]
    public string? ClosedAt { get; set; }

    [JsonPropertyName("confidential")]
    public bool Confidential { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("discussion_locked")]
    public string? DiscussionLocked { get; set; }

    [JsonPropertyName("due_date")]
    public DateTimeOffset DueDate { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("iid")]
    public long Iid { get; set; }

    [JsonPropertyName("last_edited_at")]
    public string? LastEditedAt { get; set; }

    [JsonPropertyName("last_edited_by_id")]
    public long LastEditedById { get; set; }

    [JsonPropertyName("milestone_id")]
    public string? MilestoneId { get; set; }

    [JsonPropertyName("moved_to_id")]
    public string? MovedToId { get; set; }

    [JsonPropertyName("duplicated_to_id")]
    public string? DuplicatedToId { get; set; }

    [JsonPropertyName("project_id")]
    public long ProjectId { get; set; }

    [JsonPropertyName("relative_position")]
    public long RelativePosition { get; set; }

    [JsonPropertyName("state_id")]
    public long StateId { get; set; }

    [JsonPropertyName("time_estimate")]
    public long TimeEstimate { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("updated_by_id")]
    public long UpdatedById { get; set; }

    [JsonPropertyName("url")]
    public Uri? Url { get; set; }

    [JsonPropertyName("total_time_spent")]
    public long TotalTimeSpent { get; set; }

    [JsonPropertyName("time_change")]
    public long TimeChange { get; set; }

    [JsonPropertyName("human_total_time_spent")]
    public string? HumanTotalTimeSpent { get; set; }

    [JsonPropertyName("human_time_change")]
    public string? HumanTimeChange { get; set; }

    [JsonPropertyName("human_time_estimate")]
    public string? HumanTimeEstimate { get; set; }

    [JsonPropertyName("assignee_ids")]
    public List<long>? AssigneeIds { get; set; }

    [JsonPropertyName("assignee_id")]
    public long AssigneeId { get; set; }

    [JsonPropertyName("labels")]
    public List<Label>? Labels { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }
}

public partial class ObjectAttributes
{
    [JsonPropertyName("attachment")]
    public string? Attachment { get; set; }

    [JsonPropertyName("change_position")]
    public string? ChangePosition { get; set; }

    [JsonPropertyName("commit_id")]
    public string? CommitId { get; set; }

    [JsonPropertyName("discussion_id")]
    public string? DiscussionId { get; set; }

    [JsonPropertyName("line_code")]
    public string? LineCode { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("noteable_id")]
    public long NoteableId { get; set; }

    [JsonPropertyName("noteable_type")]
    public string? NoteableType { get; set; }

    [JsonPropertyName("original_position")]
    public string? OriginalPosition { get; set; }

    [JsonPropertyName("position")]
    public string? Position { get; set; }

    [JsonPropertyName("resolved_at")]
    public string? ResolvedAt { get; set; }

    [JsonPropertyName("resolved_by_id")]
    public string? ResolvedById { get; set; }

    [JsonPropertyName("resolved_by_push")]
    public string? ResolvedByPush { get; set; }

    [JsonPropertyName("st_diff")]
    public string? StDiff { get; set; }

    [JsonPropertyName("system")]
    public bool System { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
