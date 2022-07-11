namespace Share.Models.ResourceGroupDtos;
/// <summary>
/// 资源组
/// </summary>
public class ResourceGroupFilterDto : FilterBase
{
    [MaxLength(100)]
    public string? Name { get; set; }
    /// <summary>
    /// 展示类型
    /// </summary>
    public LayoutType? LayoutType { get; set; }
    /// <summary>
    /// 所属导航类型
    /// </summary>
    public NavigationType? Navigation { get; set; }
    public Guid? EnvironmentId { get; set; }
    public Guid? UserId { get; set; }
}
