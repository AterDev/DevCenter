namespace Share.Models.CommentDtos;

public class CommentAddDto
{
    /// <summary>
    /// 评论内容
    /// </summary>
    [MaxLength(2000)]
    public string? Content { get; set; }
    public Guid BlogId { get; set; } = default!;
    public Guid UserId { get; set; } = default!;

}
