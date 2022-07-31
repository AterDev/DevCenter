namespace Share.Models.BlogTagDtos;
/// <summary>
/// 博客标签列表元素
/// </summary>
public class BlogTagItemDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(20)]
    public string? Color { get; set; }
    [MaxLength(30)]
    public string? Icon { get; set; }
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public Status Status { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
    
}
