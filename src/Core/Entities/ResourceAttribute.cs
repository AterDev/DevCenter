namespace Core.Entities
{
    /// <summary>
    /// 资源属性值 
    /// </summary>
    public class ResourceAttribute : EntityBase
    {
        [MaxLength(50)]
        public string DisplayName { get; set; }
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;
        public ValueType Type { get; set; } = ValueType.String;
        public bool IsEnable { get; set; } = true;
        [MaxLength(2000)]
        public string Value { get; set; } = string.Empty;
        /// <summary>
        /// 排序 
        /// </summary>
        public short Sort { get; set; } = 0;

        public Resource Resource { get; set; } = default!;
    }
}