namespace Core.Models
{
    /// <summary>
    /// 资源组
    /// </summary>
    public class ResourceGroup : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(400)]
        public string? Descriptioin { get; set; }
        /// <summary>
        /// 所属环境
        /// </summary>
        [MaxLength(50)]
        public Environment Environment { get; set; } = default!;
        public List<Resource>? Resources { get; set; }
        public ResourceGroup(string name)
        {
            Name = name;
        }
        private ResourceGroup()
        {

        }
    }
}