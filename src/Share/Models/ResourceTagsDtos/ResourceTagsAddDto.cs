namespace Share.Models.ResourceTagsDtos;
/// <summary>
/// 资源标识 
/// </summary>
public class ResourceTagsAddDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public string? Color { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;

}
