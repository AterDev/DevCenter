namespace Share.Models.ResourceDtos;
/// <summary>
/// 资源
/// </summary>
public class ResourceAddDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(400)]
    public string? Description { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public Guid ResourceTypeId { get; set; } = default!;
    public Guid GroupId { get; set; } = default!;

}
