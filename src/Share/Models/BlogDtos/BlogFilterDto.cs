namespace Share.Models.BlogDtos;
/// <summary>
/// 文章内容查询筛选
/// </summary>
public class BlogFilterDto : FilterBase
{
    /// <summary>
    /// 标题
    /// </summary>
    [MaxLength(100)]
    public string? Title { get; set; }
    public Guid? UserId { get; set; } = default!;
    public Guid? CatalogId { get; set; } = default!;

}
