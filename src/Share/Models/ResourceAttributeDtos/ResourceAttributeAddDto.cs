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
    public bool? IsEnable { get; set; } = true;
    [MaxLength(2000)]
    public string? Value { get; set; }
    /// <summary>
    /// 排序 
    /// </summary>
    public short? Sort { get; set; } = 0;
    public Core.Entities.ValueType? Type { get; set; } = Core.Entities.ValueType.String;
    public Guid? ResourceId { get; set; } = default!;

}
