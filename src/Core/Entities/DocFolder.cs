namespace Core.Entities;

/// <summary>
/// 文档目录
/// </summary>
public class DocFolder : EntityBase
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    public DocFolder? Parent { get; set; }
    public List<DocFolder>? Children { get; set; }
    public List<Document>? Documents { get; set; }
}