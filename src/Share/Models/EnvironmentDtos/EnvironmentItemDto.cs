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
    public string? Color { get; set; }
    public DateTimeOffset CreatedTime { get; set; } = default!;
}
