using Microsoft.EntityFrameworkCore;

namespace Core.Entities.GitLab;
/// <summary>
/// 提交内容
/// </summary>
[Index(nameof(SourceId))]
[Index(nameof(Name))]
public class GitLabCommit : EntityBase
{
    [MaxLength(100)]
    public string SourceId { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(1000)]
    public required string Message { get; set; }

    public int AddCount { get; set; }
    public int DeleteCount { get; set; }
    public int TotalCount { get; set; }

    public required GitLabUser User { get; set; }
    public required GitLabProject Project { get; set; }
}
