namespace Core.Models
{
    /// <summary>
    /// 代码片段
    /// </summary>
    public class CodeSnippet : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(200)]
        public string? Description { get; set; }
        [MaxLength(20)]
        public string Format { get; set; } = "text";
        [MaxLength(2000)]
        public string? Content { get; set; }

    }
}
