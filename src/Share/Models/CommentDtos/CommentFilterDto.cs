namespace Share.Models.CommentDtos;

public class CommentFilterDto : FilterBase
{
    public Guid? BlogId { get; set; } = default!;
    public Guid? UserId { get; set; } = default!;

}
