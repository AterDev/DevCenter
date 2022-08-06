using Core.Entities.Resource;
using Environment = Core.Entities.Resource.Environment;

namespace Share.Models.ResourceGroupDtos;
/// <summary>
/// 资源组
/// </summary>
public class ResourceGroupItemDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
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
    public LayoutType LayoutType { get; set; }
    /// <summary>
    /// 所属导航类型
    /// </summary>
    public NavigationType Navigation { get; set; }

    public Guid Id { get; set; } = default!;

    public Environment Environment { get; set; }

    public List<Resource> Resource { get; set; }

}
