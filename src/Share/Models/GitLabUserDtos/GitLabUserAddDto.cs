using Core.Entities.GitLab;
namespace Share.Models.GitLabUserDtos;
/// <summary>
/// gitlab 用户信息添加时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabUser"/>
public class GitLabUserAddDto
{
    public int SourceId { get; set; }
    [MaxLength(200)]
    public required string Email { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    public Status? Status { get; set; }
    
}
