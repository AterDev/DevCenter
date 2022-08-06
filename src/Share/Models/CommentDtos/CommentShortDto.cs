namespace Share.Models.CommentDtos;

public class CommentShortDto
{
    public Blog Blog { get; set; } = default!;
    public User User { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public Status Status { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;

}
