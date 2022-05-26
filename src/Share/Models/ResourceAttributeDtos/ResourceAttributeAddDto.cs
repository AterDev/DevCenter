namespace Share.Models.ResourceAttributeDtos;
/// <summary>
/// 资源属性值 
/// </summary>
public class ResourceAttributeAddDto
{
    [MaxLength(50)]
    public string DisplayName { get; set; } = default!;
    [MaxLength(60)]
    public string Name { get; set; } = default!;
    public bool IsEnable { get; set; } = default!;
    [MaxLength(2000)]
    public string Value { get; set; } = default!;
    /// <summary>
    /// 排序 
    /// </summary>
    public short Sort { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public Guid TypeId { get; set; } = default!;
    public Guid ResourceId { get; set; } = default!;

}
