namespace Share.Models.BlogTagDtos;
/// <summary>
/// 博客标签更新时请求结构
/// </summary>
public class BlogTagUpdateDto
{
    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(20)]
    public string? Color { get; set; }
    [MaxLength(30)]
    public string? Icon { get; set; }
    public Status? Status { get; set; }
    public bool? IsDeleted { get; set; }

}
