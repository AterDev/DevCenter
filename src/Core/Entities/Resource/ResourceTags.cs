namespace Core.Entities.Resource;

/// <summary>
/// 资源标识 
/// </summary>
public class ResourceTags : EntityBase
{
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(20)]
    public string? Color { get; set; } = Helper.GetRandColor();
    [MaxLength(30)]
    public string? Icon { get; set; }

    public List<Resource>? Resources { get; set; }

}
