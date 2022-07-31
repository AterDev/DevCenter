namespace Core.Entities.Blog;

public class Comment : EntityBase
{
    public Blog Blog { get; set; } = null!;
    public User User { get; set; } = null!;
    /// <summary>
    /// 评论内容
    /// </summary>
    [MaxLength(2000)]
    public string? Content { get; set; }
}
