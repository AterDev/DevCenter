﻿namespace Core.Entities.Blog;
/// <summary>
/// 博客标签
/// </summary>
public class BlogTag : EntityBase
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [MaxLength(20)]
    public string? Color { get; set; } = Helper.GetRandColor();
    [MaxLength(30)]
    public string? Icon { get; set; }
    public List<Blog>? Blogs { get; set; }
}
