using Share.Models.ResourceAttributeDtos;

namespace Share.Models.ResourceDtos;
/// <summary>
/// 资源
/// </summary>
public class ResourceUpdateDto
{
    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(400)]
    public string? Description { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? ResourceTypeId { get; set; }
    public Guid? GroupId { get; set; }
    /// <summary>
    /// 包含属性
    /// </summary>
    public List<ResourceAttributeAddDto>? AttributeAddItem { get; set; }
    /// <summary>
    /// 标签id
    /// </summary>
    public List<Guid>? TagIds { get; set; }
}
