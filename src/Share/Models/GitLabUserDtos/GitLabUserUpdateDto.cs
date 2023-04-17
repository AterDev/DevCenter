using Core.Entities.GitLab;
namespace Share.Models.GitLabUserDtos;
/// <summary>
/// gitlab 用户信息更新时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabUser"/>
public class GitLabUserUpdateDto
{
    public int? SourceId { get; set; }
    [MaxLength(200)]
    public string Email { get; set; } = default!;
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public Status? Status { get; set; }
    
}
