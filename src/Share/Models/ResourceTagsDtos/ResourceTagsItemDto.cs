namespace Share.Models.ResourceTagsDtos;
/// <summary>
/// 资源标识 
/// </summary>
public class ResourceTagsItemDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public string? Color { get; set; }
    public Guid Id { get; set; } = default!;

}
