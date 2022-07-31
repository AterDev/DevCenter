using ValueType = Core.Models.ValueType;

namespace Core.Entities.Resource;

/// <summary>
/// 资源属性定义
/// </summary>
public class ResourceAttributeDefine : EntityBase
{
    [MaxLength(50)]
    public string DisplayName { get; set; }
    [MaxLength(60)]
    public string Name { get; set; } = string.Empty;
    public ValueType Type { get; set; } = ValueType.String;
    public bool IsEnable { get; set; } = true;
    /// <summary>
    /// 是否必须
    /// </summary>
    public bool Required { get; set; } = false;
    /// <summary>
    /// 排序 
    /// </summary>
    public short Sort { get; set; } = 0;
    /// <summary>
    /// 关联的类型定义
    /// </summary>
    public List<ResourceTypeDefinition>? TypeDefinitions { get; set; }

}