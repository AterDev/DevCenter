namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段添加时请求结构
/// </summary>
public class CodeSnippetAddDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }
    /// <summary>
    /// 内容
    /// </summary>
    [MaxLength(5000)]
    public string? Content { get; set; }
    /// <summary>
    /// 语言类型
    /// </summary>
    public Language Language { get; set; } = default!;
    /// <summary>
    /// 类型
    /// </summary>
    public CodeType CodeType { get; set; } = default!;
    public Guid LibraryId { get; set; } = default!;

}
