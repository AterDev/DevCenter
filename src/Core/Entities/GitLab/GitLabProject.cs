using Microsoft.EntityFrameworkCore;

namespace Core.Entities.GitLab;
/// <summary>
/// gitlab 项目信息
/// </summary>
[Index(nameof(SourceId))]
[Index(nameof(Name))]
public class GitLabProject : EntityBase
{
    public int SourceId { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    public List<GitLabCommit>? Commits { get; set; }
}
