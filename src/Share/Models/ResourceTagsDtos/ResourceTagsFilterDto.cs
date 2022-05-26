namespace Share.Models.ResourceTagsDtos;
/// <summary>
/// 资源标识 
/// </summary>
public class ResourceTagsFilterDto : FilterBase
{
    [MaxLength(100)]
    public string? Name { get; set; }

}
