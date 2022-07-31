using Core.Entities.Resource;

namespace Share.Models.ResourceDtos;
/// <summary>
/// 资源
/// </summary>
public class ResourceShortDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(400)]
    public string? Description { get; set; }

    /// <summary>
    /// 资源的类型
    /// </summary>
    public ResourceTypeDefinition ResourceType { get; set; } = default!;
    /// <summary>
    /// 所属资源组
    /// </summary>
    public ResourceGroup Group { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
