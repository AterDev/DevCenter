using Core.Entities.GitLab;
namespace Share.Models.GitLabCommitDtos;
/// <summary>
/// 提交内容列表元素
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabCommit"/>
public class GitLabCommitItemDto
{
    public int SourceId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(1000)]
    public string Message { get; set; } = default!;
    public int AddCount { get; set; }
    public int DeleteCount { get; set; }
    public int TotalCount { get; set; }
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    public Status? Status { get; set; }
    
}
