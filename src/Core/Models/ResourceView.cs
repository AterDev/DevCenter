namespace Core.Models
{
    /// <summary>
    /// 资源视图
    /// </summary>
    public class ResourceView
    {
        public string Name { get; set; } = default!;
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
    }
}
