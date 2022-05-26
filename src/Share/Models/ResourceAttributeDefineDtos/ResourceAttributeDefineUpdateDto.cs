namespace Share.Models.ResourceAttributeDefineDtos;
/// <summary>
/// 资源属性定义
/// </summary>
public class ResourceAttributeDefineUpdateDto
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
    /// <summary>
    /// 排序 
    /// </summary>
    public short? Sort { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? TypeId { get; set; } = default!;

}
