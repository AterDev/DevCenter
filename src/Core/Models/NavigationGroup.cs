namespace Core.Models;

/// <summary>
/// 导航分组
/// </summary>
public class NavigationGroup : EntityBase
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;

    public List<Navigation>? Navigations { get; set; }
}