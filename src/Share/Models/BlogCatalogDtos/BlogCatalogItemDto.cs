namespace Share.Models.BlogCatalogDtos;

public class BlogCatalogItemDto
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    [MaxLength(50)]
    public string? Type { get; set; }
    public short Sort { get; set; } = default!;
    public short Level { get; set; } = default!;
    public Guid? ParentId { get; set; }
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public Status Status { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;

}
