using Core.Entities.Code;

namespace Core.Entities;

/// <summary>
/// 代码目录
/// </summary>
public class CodeFolder : EntityBase
{
    [MaxLength(100)]
    public required string Name { get; set; }

    public CodeFolder? Parent { get; set; }
    public List<CodeFolder>? Children { get; set; }
    public List<CodeSnippet>? Documents { get; set; }
}