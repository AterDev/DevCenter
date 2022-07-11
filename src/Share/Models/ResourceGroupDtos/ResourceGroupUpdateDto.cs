namespace Share.Models.ResourceGroupDtos;
/// <summary>
/// 资源组
/// </summary>
public class ResourceGroupUpdateDto
{
    [MaxLength(100)]
    public string? Name { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(400)]
    public string? Descriptioin { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    public int? Sort { get; set; } = 0;
    /// <summary>
    /// 展示类型
    /// </summary>
    public LayoutType? LayoutType { get; set; }
    /// <summary>
    /// 所属导航类型
    /// </summary>
    public NavigationType? Navigation { get; set; }
    public Guid? EnvironmentId { get; set; } = default!;

}
