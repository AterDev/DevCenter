using Core.Entities.GitLab;
namespace Share.Models.GitLabUserDtos;
/// <summary>
/// gitlab 用户信息查询筛选
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabUser"/>
public class GitLabUserFilterDto : FilterBase
{
    public int? SourceId { get; set; }
    [MaxLength(200)]
    public string? Email { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
    public Status? Status { get; set; }
    
}
