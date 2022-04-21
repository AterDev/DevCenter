namespace Core.Models
{
    /// <summary>
    /// 文件夹
    /// </summary>
    public class CodeFolder : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        public CodeFolder? Parent { get; set; }
        public List<CodeFolder>? Children { get; set; }
        public List<CodeSnippet>? Documents { get; set; }
    }
}