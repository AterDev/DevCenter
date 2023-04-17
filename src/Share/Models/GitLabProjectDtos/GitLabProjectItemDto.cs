using Core.Entities.GitLab;
namespace Share.Models.GitLabProjectDtos;
/// <summary>
/// gitlab 项目信息列表元素
/// </summary>
/// <inheritdoc cref="Core.Entities.GitLab.GitLabProject"/>
public class GitLabProjectItemDto
{
    public int SourceId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    public Status? Status { get; set; }
    
}
