namespace Share.Models.BlogCatalogDtos;

public class BlogCatalogAddDto
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    [MaxLength(50)]
    public string? Type { get; set; }
    public short Sort { get; set; } = default!;
    public short Level { get; set; } = default!;
    public Guid? ParentId { get; set; }
    
}
