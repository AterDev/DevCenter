namespace Share.Models.ResourceDtos;
/// <summary>
/// 资源
/// </summary>
public class ResourceAddDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(400)]
    public string? Description { get; set; }

    /// <summary>
    /// 资源类型id
    /// </summary>
    public Guid ResourceTypeId { get; set; } = default!;
    /// <summary>
    /// 资源组
    /// </summary>
    public Guid GroupId { get; set; } = default!;
    /// <summary>
    /// 包含属性
    /// </summary>
    public List<ResourceAttribute>? Attributes { get; set; }
    /// <summary>
    /// 标签id
    /// </summary>
    public List<Guid>? TagIds { get; set; }

}
