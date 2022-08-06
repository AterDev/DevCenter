namespace Share.Models.BlogCatalogDtos;

public class BlogCatalogFilterDto : FilterBase
{
    [MaxLength(50)]
    public string? Name { get; set; }
    public short? Sort { get; set; }
    public short? Level { get; set; }
    public Guid? ParentId { get; set; } = default!;

}
