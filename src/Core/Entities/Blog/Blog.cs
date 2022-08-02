namespace Core.Entities.Blog;

/// <summary>
/// 文章内容
/// </summary>
public partial class Blog : EntityBase
{
    /// <summary>
    /// 标题
    /// </summary>
    [MaxLength(100)]
    public string Title { get; set; } = null!;
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

    public User User { get; set; } = null!;
    /// <summary>
    /// 仅个人查看
    /// </summary>
    public bool? IsPrivate { get; set; }
    /// <summary>
    /// 文章内容
    /// </summary>
    [MaxLength(12000)]
    public string? Content { get; set; }
    /// <summary>
    /// 所属目录
    /// </summary>
    public BlogCatalog? Catalog { get; set; }
    /// <summary>
    /// 评论
    /// </summary>
    public List<Comment>? Comments { get; set; }
    /// <summary>
    /// 标签
    /// </summary>
    public List<BlogTag>? BlogTags { get; set; }
}
