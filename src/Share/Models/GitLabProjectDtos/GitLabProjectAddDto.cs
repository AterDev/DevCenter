using Core.Entities.GitLab;
namespace Share.Models.GitLabProjectDtos;
/// <summary>
/// gitlab 项目信息添加时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabProject"/>
public class GitLabProjectAddDto
{
    public int SourceId { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    public Status? Status { get; set; }
    
}
