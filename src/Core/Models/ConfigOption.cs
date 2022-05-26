namespace Core.Models
{
    /// <summary>
    /// 可配置的选项
    /// </summary>
    public class ConfigOption : EntityBase
    {
        [MaxLength(60)]
        public string Name { get; set; } = default!;

        public ValueType Type { get; set; } = ValueType.Default;
        [MaxLength(20)]
        public string? DisplayValue { get; set; }
        [MaxLength(100)]
        public string Value { get; set; } = null!;
        [MaxLength(40)]
        public string? MinValue { get; set; }
        [MaxLength(40)]
        public string? MaxValue { get; set; }
    }


}
