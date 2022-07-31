namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段查询筛选
/// </summary>
public class CodeSnippetFilterDto : FilterBase
{
    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(100)]
    public string? Name { get; set; }
    /// <summary>
    /// 语言类型
    /// </summary>
    public Language? Language { get; set; }
    /// <summary>
    /// 类型
    /// </summary>
    public CodeType? CodeType { get; set; }
    public Guid? UserId { get; set; } = default!;
    public Guid? LibraryId { get; set; } = default!;

}
