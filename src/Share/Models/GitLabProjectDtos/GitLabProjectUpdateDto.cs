using Core.Entities.GitLab;
namespace Share.Models.GitLabProjectDtos;
/// <summary>
/// gitlab 项目信息更新时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabProject"/>
public class GitLabProjectUpdateDto
{
    public int? SourceId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public Status? Status { get; set; }
    
}
