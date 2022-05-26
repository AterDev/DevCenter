namespace Share.Models.ResourceDtos;
/// <summary>
/// 资源
/// </summary>
public class ResourceItemDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(400)]
    public string? Description { get; set; }
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
