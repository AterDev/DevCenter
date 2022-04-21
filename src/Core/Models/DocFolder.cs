namespace Core.Models
{
    /// <summary>
    /// 文件夹
    /// </summary>
    public class DocFolder : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        public DocFolder? Parent { get; set; }
        public List<DocFolder>? Children { get; set; }
        public List<Document>? Documents { get; set; }
    }
}