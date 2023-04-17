using Core.Entities.GitLab;
namespace Share.Models.GitLabUserDtos;
/// <summary>
/// gitlab 用户信息列表元素
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabUser"/>
public class GitLabUserItemDto
{
    public int SourceId { get; set; }
    [MaxLength(200)]
    public string Email { get; set; } = default!;
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    public Status? Status { get; set; }
    
}
