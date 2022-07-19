using ValueType = Core.Entities.ValueType;

namespace Share.Models.ConfigOptionDtos;
/// <summary>
/// 可配置的选项
/// </summary>
public class ConfigOptionShortDto
{
    [MaxLength(60)]
    public string Name { get; set; } = default!;

    public ValueType Type { get; set; } = default!;
    [MaxLength(20)]
    public string? DisplayValue { get; set; }
    [MaxLength(100)]
    public string Value { get; set; } = default!;
    [MaxLength(40)]
    public string? MinValue { get; set; }
    [MaxLength(40)]
    public string? MaxValue { get; set; }
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
