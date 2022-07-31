namespace Share.Models.BlogDtos;
/// <summary>
/// 文章内容添加时请求结构
/// </summary>
public class BlogAddDto
{
    /// <summary>
    /// 标题
    /// </summary>
    [MaxLength(100)]
    public string Title { get; set; } = default!;
    /// <summary>
    /// 概要
    /// </summary>
    [MaxLength(500)]
    public string? Summary { get; set; }
    /// <summary>
    /// 作者名称
    /// </summary>
    [MaxLength(100)]
    public string? AuthorName { get; set; }
    /// <summary>
    /// 仅个人查看
    /// </summary>
    public bool? IsPrivate { get; set; }
    /// <summary>
    /// 文章扩展内容
    /// </summary>
    public string? Content { get; set; }
    public Guid UserId { get; set; } = default!;
    public Guid CatalogId { get; set; } = default!;

}
