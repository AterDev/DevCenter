using ValueType = Core.Models.ValueType;

namespace Share.Models.ResourceAttributeDtos;
/// <summary>
/// 资源属性值 
/// </summary>
public class ResourceAttributeShortDto
{
    [MaxLength(50)]
    public string DisplayName { get; set; } = default!;
    [MaxLength(60)]
    public string Name { get; set; } = default!;
    public ValueType Type { get; set; } = default!;
    public bool IsEnable { get; set; } = default!;
    /// <summary>
    /// 排序 
    /// </summary>
    public short Sort { get; set; } = default!;

    public Resource Resource { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
