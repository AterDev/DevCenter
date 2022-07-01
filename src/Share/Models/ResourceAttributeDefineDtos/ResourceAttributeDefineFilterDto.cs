namespace Share.Models.ResourceAttributeDefineDtos;
/// <summary>
/// 资源属性定义
/// </summary>
public class ResourceAttributeDefineFilterDto : FilterBase
{
    [MaxLength(50)]
    public string? DisplayName { get; set; }
    [MaxLength(60)]
    public string? Name { get; set; }
    public bool? IsEnable { get; set; }
    /// <summary>
    /// 是否必须
    /// </summary>
    public bool? Required { get; set; }
    public Guid? TypeId { get; set; } = default!;

}
