using Core.Entities.GitLab;
namespace Share.Models.GitLabCommitDtos;
/// <summary>
/// 提交内容更新时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabCommit"/>
public class GitLabCommitUpdateDto
{
    public int? SourceId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(1000)]
    public string Message { get; set; } = default!;
    public int? AddCount { get; set; }
    public int? DeleteCount { get; set; }
    public int? TotalCount { get; set; }
    public Status? Status { get; set; }
    public Guid ProjectId { get; set; } = default!;
    public Guid UserId { get; set; } = default!;
    
}
