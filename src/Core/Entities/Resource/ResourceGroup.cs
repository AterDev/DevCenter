namespace Core.Entities.Resource;

/// <summary>
/// 资源组
/// </summary>
public class ResourceGroup : EntityBase
{
    [MaxLength(100)]
    public required string Name { get; set; } 
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(400)]
    public string? Descriptioin { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; } = 0;
    /// <summary>
    /// 展示类型
    /// </summary>
    public LayoutType LayoutType { get; set; } = LayoutType.Default;
    /// <summary>
    /// 所属导航类型
    /// </summary>
    public NavigationType Navigation { get; set; } = NavigationType.Default;
    /// <summary>
    /// 所属环境
    /// </summary>
    [MaxLength(50)]
    public Environment Environment { get; set; } = default!;
    public List<Resource>? Resources { get; set; }
    public List<Role>? Roles { get; set; }

}

