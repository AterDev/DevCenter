using Core.Entities.GitLab;
namespace Share.Models.GitLabCommitDtos;
/// <summary>
/// 提交内容查询筛选
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabEvent"/>
public class GitLabCommitFilterDto : FilterBase
{
    public int? SourceId { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
    public int? AddCount { get; set; }
    public int? DeleteCount { get; set; }
    public int? TotalCount { get; set; }
    public Status? Status { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ProjectId { get; set; }
    
}
