namespace Share.Models.ResourceTypeDefinitionDtos;
/// <summary>
/// 资源类型的定义
/// </summary>
public class ResourceTypeDefinitionItemDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(400)]
    public string? Description { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(300)]
    public string? Icon { get; set; }

    /// <summary>
    /// 颜色
    /// </summary>
    [MaxLength(12)]
    public string? Color { get; set; }
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
