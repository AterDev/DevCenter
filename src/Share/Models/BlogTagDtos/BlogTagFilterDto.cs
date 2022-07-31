namespace Share.Models.BlogTagDtos;
/// <summary>
/// 博客标签查询筛选
/// </summary>
public class BlogTagFilterDto : FilterBase
{
    [MaxLength(100)]
    public string? Name { get; set; }
    
}
