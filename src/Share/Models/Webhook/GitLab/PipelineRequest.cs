namespace Share.Models.Webhook.GitLab;

public partial class PipelineRequest
{
    [JsonPropertyName("object_kind")]
    public string? ObjectKind { get; set; }

    [JsonPropertyName("object_attributes")]
    public ObjectAttributes? ObjectAttributes { get; set; }

    [JsonPropertyName("merge_request")]
    public string? MergeRequest { get; set; }

    [JsonPropertyName("user")]
    public User? User { get; set; }

    [JsonPropertyName("project")]
    public Project? Project { get; set; }

    [JsonPropertyName("commit")]
    public Commit? Commit { get; set; }

    [JsonPropertyName("builds")]
    public List<Build>? Builds { get; set; }
}

public partial class Build
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("stage")]
    public string? Stage { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("started_at")]
    public string? StartedAt { get; set; }

    [JsonPropertyName("finished_at")]
    public string? FinishedAt { get; set; }

    [JsonPropertyName("duration")]
    public double? Duration { get; set; }

    [JsonPropertyName("queued_duration")]
    public double? QueuedDuration { get; set; }

    [JsonPropertyName("when")]
    public string? When { get; set; }

    [JsonPropertyName("manual")]
    public bool Manual { get; set; }

    [JsonPropertyName("allow_failure")]
    public bool AllowFailure { get; set; }

    [JsonPropertyName("user")]
    public User? User { get; set; }

    [JsonPropertyName("runner")]
    public Runner? Runner { get; set; }

    [JsonPropertyName("artifacts_file")]
    public ArtifactsFile? ArtifactsFile { get; set; }

    [JsonPropertyName("environment")]
    public string? Environment { get; set; }
}

public partial class ArtifactsFile
{
    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }
}

public partial class Runner
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("runner_type")]
    public string? RunnerType { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("is_shared")]
    public bool IsShared { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }
}

public partial class User
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("avatar_url")]
    public Uri? AvatarUrl { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }
}

public partial class Commit
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonPropertyName("url")]
    public Uri? Url { get; set; }

    [JsonPropertyName("author")]
    public Author? Author { get; set; }
}

public partial class Author
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }
}

public partial class ObjectAttributes
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    [JsonPropertyName("tag")]
    public bool Tag { get; set; }

    [JsonPropertyName("sha")]
    public string? Sha { get; set; }

    [JsonPropertyName("before_sha")]
    public string? BeforeSha { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("detailed_status")]
    public string? DetailedStatus { get; set; }

    [JsonPropertyName("stages")]
    public List<string>? Stages { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("finished_at")]
    public string? FinishedAt { get; set; }

    [JsonPropertyName("duration")]
    public long Duration { get; set; }

    [JsonPropertyName("queued_duration")]
    public long QueuedDuration { get; set; }

    [JsonPropertyName("variables")]
    public List<string?>? Variables { get; set; }
}

public partial class Project
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("web_url")]
    public Uri? WebUrl { get; set; }

    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; set; }

    [JsonPropertyName("git_ssh_url")]
    public string? GitSshUrl { get; set; }

    [JsonPropertyName("git_http_url")]
    public Uri? GitHttpUrl { get; set; }

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("visibility_level")]
    public long VisibilityLevel { get; set; }

    [JsonPropertyName("path_with_namespace")]
    public string? PathWithNamespace { get; set; }

    [JsonPropertyName("default_branch")]
    public string? DefaultBranch { get; set; }

    [JsonPropertyName("ci_config_path")]
    public string? CiConfigPath { get; set; }
}
