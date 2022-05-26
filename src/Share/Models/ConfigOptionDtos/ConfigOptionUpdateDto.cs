namespace Share.Models.ConfigOptionDtos;
/// <summary>
/// 可配置的选项
/// </summary>
public class ConfigOptionUpdateDto
{
    [MaxLength(60)]
    public string? Name { get; set; }
    [MaxLength(20)]
    public string? DisplayValue { get; set; }
    [MaxLength(100)]
    public string? Value { get; set; }
    [MaxLength(40)]
    public string? MinValue { get; set; }
    [MaxLength(40)]
    public string? MaxValue { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? TypeId { get; set; } = default!;

}
