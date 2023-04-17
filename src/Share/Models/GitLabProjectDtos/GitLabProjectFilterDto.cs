using Core.Entities.GitLab;
namespace Share.Models.GitLabProjectDtos;
/// <summary>
/// gitlab 项目信息查询筛选
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabProject"/>
public class GitLabProjectFilterDto : FilterBase
{
    public int? SourceId { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
    public Status? Status { get; set; }
    
}
