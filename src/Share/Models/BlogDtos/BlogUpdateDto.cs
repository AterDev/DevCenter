namespace Share.Models.BlogDtos;
/// <summary>
/// 文章内容更新时请求结构
/// </summary>
public class BlogUpdateDto
{
    /// <summary>
    /// 标题
    /// </summary>
    [MaxLength(100)]
    public string? Title { get; set; }
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
    /// 文章内容
    /// </summary>
    [MaxLength(12000)]
    public string? Content { get; set; }
    public Status? Status { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid? UserId { get; set; } = default!;

}
