namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段列表元素
/// </summary>
public class CodeSnippetItemDto
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
    /// 语言类型
    /// </summary>
    public Language Language { get; set; } = default!;
    /// <summary>
    /// 类型
    /// </summary>
    public CodeType CodeType { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public Status Status { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
    
}
