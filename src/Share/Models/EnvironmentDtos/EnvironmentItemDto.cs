namespace Share.Models.EnvironmentDtos;
/// <summary>
/// 环境
/// </summary>
public class EnvironmentItemDto
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    [MaxLength(200)]
    public string? Description { get; set; }
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
