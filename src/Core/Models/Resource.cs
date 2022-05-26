namespace Core.Models
{
    /// <summary>
    /// 资源
    /// </summary>
    public class Resource : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(400)]
        public string? Description { get; set; }

        /// <summary>
        /// 资源的类型
        /// </summary>
        public ResourceTypeDefinition ResourceType { get; set; } = default!;
        /// <summary>
        /// 资源属性值
        /// </summary>
        public List<ResourceAttribute>? Attributes { get; set; }
        /// <summary>
        /// 所属资源组
        /// </summary>
        public ResourceGroup Group { get; set; } = default!;

        public List<ResourceTags>? Tags { get; set; }

        public Resource(string name)
        {
            Name = name;
        }

        private Resource() { }
    }
}
