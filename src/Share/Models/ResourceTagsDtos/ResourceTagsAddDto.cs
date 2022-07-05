namespace Share.Models.ResourceTagsDtos;
/// <summary>
/// 资源标识 
/// </summary>
public class ResourceTagsAddDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public string? Color { get; set; }
    [MaxLength(30)]
    public string? Icon { get; set; }

}
