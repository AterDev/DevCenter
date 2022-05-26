namespace Share.Models.ResourceAttributeDefineDtos;
/// <summary>
/// 资源属性定义
/// </summary>
public class ResourceAttributeDefineAddDto
{
    [MaxLength(50)]
    public string DisplayName { get; set; } = default!;
    [MaxLength(60)]
    public string Name { get; set; } = default!;
    public bool IsEnable { get; set; } = default!;
    /// <summary>
    /// 是否必须
    /// </summary>
    public bool Required { get; set; } = default!;
    /// <summary>
    /// 排序 
    /// </summary>
    public short Sort { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public Guid TypeId { get; set; } = default!;

}
