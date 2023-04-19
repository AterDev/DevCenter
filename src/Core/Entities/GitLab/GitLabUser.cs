using Microsoft.EntityFrameworkCore;

namespace Core.Entities.GitLab;

/// <summary>
/// gitlab 用户信息
/// </summary>
[Index(nameof(SourceId), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Name))]
public class GitLabUser : EntityBase
{
    public int SourceId { get; set; }
    [MaxLength(200)]
    public required string Email { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(200)]
    public string? AvatarUrl { get; set; }

    public List<GitLabEvent>? Commits { get; set; }
}
