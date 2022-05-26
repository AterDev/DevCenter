namespace Share.Models.ResourceGroupDtos;
/// <summary>
/// 资源组
/// </summary>
public class ResourceGroupFilterDto : FilterBase
{
    [MaxLength(100)]
    public string? Name { get; set; }
    public Guid? EnvironmentId { get; set; } = default!;

}
