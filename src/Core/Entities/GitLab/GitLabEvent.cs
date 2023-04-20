using Microsoft.EntityFrameworkCore;

namespace Core.Entities.GitLab;
/// <summary>
/// push event
/// </summary>
[Index(nameof(SourceId))]
[Index(nameof(CommitTitle))]
[Index(nameof(Year))]
[Index(nameof(Month))]
[Index(nameof(Day))]
public class GitLabEvent : EntityBase
{
    [MaxLength(100)]
    public int SourceId { get; set; }

    [MaxLength(100)]
    public required string BranchName { get; set; }

    [MaxLength(1000)]
    public required string CommitTitle { get; set; }

    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    /// <summary>
    /// 提交数
    /// </summary>
    public int CommitCount { get; set; }
    public required GitLabUser User { get; set; }
    public required GitLabProject Project { get; set; }
}
