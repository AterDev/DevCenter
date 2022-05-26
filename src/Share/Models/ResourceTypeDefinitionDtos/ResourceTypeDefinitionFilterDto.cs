namespace Share.Models.ResourceTypeDefinitionDtos;
/// <summary>
/// 资源类型的定义
/// </summary>
public class ResourceTypeDefinitionFilterDto : FilterBase
{
    [MaxLength(100)]
    public string? Name { get; set; }

}
