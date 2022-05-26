namespace Share.Models.ResourceDtos;
/// <summary>
/// 资源
/// </summary>
public class ResourceFilterDto : FilterBase
{
    [MaxLength(100)]
    public string? Name { get; set; }
    public Guid? ResourceTypeId { get; set; } = default!;
    public Guid? GroupId { get; set; } = default!;

}
