using Core.Models;

namespace Core.Entities.Resource;

/// <summary>
/// 资源类型的定义
/// </summary>
public class ResourceTypeDefinition : EntityBase
{

    [MaxLength(100)]
    public string Name { get; set; } = default!;

    [MaxLength(400)]
    public string? Description { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(300)]
    public string? Icon { get; set; }

    /// <summary>
    /// 颜色
    /// </summary>
    [MaxLength(12)]
    public string? Color { get; set; }

    /// <summary>
    /// 包含的属性定义
    /// </summary>
    public List<ResourceAttributeDefine>? AttributeDefines { get; set; }

    public List<Resource>? Resources { get; set; }
}