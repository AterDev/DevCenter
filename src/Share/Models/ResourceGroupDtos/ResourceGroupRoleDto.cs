using Environment = Core.Models.Environment;

namespace Share.Models.ResourceGroupDtos;

/// <summary>
/// 角色对应的资源组
/// </summary>
public class ResourceGroupRoleDto
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(400)]
    public string? Descriptioin { get; set; }
    public Environment Environment { get; set; } = default!;
}
