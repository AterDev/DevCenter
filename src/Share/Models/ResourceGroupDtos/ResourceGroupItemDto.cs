using Environment = Core.Models.Environment;

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

    public Guid Id { get; set; } = default!;

    public Environment? Environment { get; set; } 

    public List<Resource>? Resource { get; set; }

}
