using Core.Entities.GitLab;
namespace Share.Models.GitLabCommitDtos;
/// <summary>
/// 提交内容添加时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabEvent"/>
public class GitLabCommitAddDto
{
    public int SourceId { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(1000)]
    public required string Message { get; set; }
    public int AddCount { get; set; }
    public int DeleteCount { get; set; }
    public int TotalCount { get; set; }
    public Status? Status { get; set; }
    public required Guid ProjectId { get; set; }
    public required Guid UserId { get; set; }

    
}
