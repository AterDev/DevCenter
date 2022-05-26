namespace Share.Models.ResourceAttributeDtos;
/// <summary>
/// 资源属性值 
/// </summary>
public class ResourceAttributeUpdateDto
{
    [MaxLength(50)]
    public string? DisplayName { get; set; }
    [MaxLength(60)]
    public string? Name { get; set; }
    public bool? IsEnable { get; set; }
    [MaxLength(2000)]
    public string? Value { get; set; }
    /// <summary>
    /// 排序 
    /// </summary>
    public short? Sort { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? TypeId { get; set; } = default!;
    public Guid? ResourceId { get; set; } = default!;

}
