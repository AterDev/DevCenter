namespace Share.Models.BlogTagDtos;
/// <summary>
/// 博客标签添加时请求结构
/// </summary>
public class BlogTagAddDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(20)]
    public string? Color { get; set; }
    [MaxLength(30)]
    public string? Icon { get; set; }
    
}
