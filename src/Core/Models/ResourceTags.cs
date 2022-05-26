namespace Core.Models
{
    /// <summary>
    /// 资源标识 
    /// </summary>
    public class ResourceTags : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Color { get; set; }


        public List<Resource>? Resources { get; set; }
        public ResourceTags(string name, string? color = "")
        {
            Name = name;
            Color = color;
        }

        private ResourceTags()
        {

        }
    }
}
