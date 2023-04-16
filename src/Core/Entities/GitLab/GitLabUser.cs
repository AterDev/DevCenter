using Microsoft.EntityFrameworkCore;

namespace Core.Entities.GitLab;

/// <summary>
/// gitlab 用户信息
/// </summary>
[Index(nameof(SourceId))]
[Index(nameof(Email))]
[Index(nameof(Name))]
public class GitLabUser : EntityBase
{
    public int SourceId { get; set; }
    [MaxLength(200)]
    public required string Email { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }

    public List<GitLabCommit>? Commits { get; set; }
}
