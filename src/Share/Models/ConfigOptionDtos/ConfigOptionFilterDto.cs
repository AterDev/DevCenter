namespace Share.Models.ConfigOptionDtos;
/// <summary>
/// 可配置的选项
/// </summary>
public class ConfigOptionFilterDto : FilterBase
{
    [MaxLength(60)]
    public string? Name { get; set; }
    [MaxLength(100)]
    public string? Value { get; set; }
    public Guid? TypeId { get; set; } = default!;

}
