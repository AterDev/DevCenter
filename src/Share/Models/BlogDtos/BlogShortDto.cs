namespace Share.Models.BlogDtos;
/// <summary>
/// 文章内容概要
/// </summary>
public class BlogShortDto
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

    public User User { get; set; } = default!;
    /// <summary>
    /// 仅个人查看
    /// </summary>
    public bool? IsPrivate { get; set; }
    /// <summary>
    /// 所属目录
    /// </summary>
    public BlogCatalog? Catalog { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public Status Status { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
    
}
