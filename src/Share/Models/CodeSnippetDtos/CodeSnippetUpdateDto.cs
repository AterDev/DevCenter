namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段更新时请求结构
/// </summary>
public class CodeSnippetUpdateDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(100)]
    public string? Name { get; set; }
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
    public Language? Language { get; set; }
    /// <summary>
    /// 类型
    /// </summary>
    public CodeType? CodeType { get; set; }
    public Status? Status { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid? UserId { get; set; } = default!;
    
}
