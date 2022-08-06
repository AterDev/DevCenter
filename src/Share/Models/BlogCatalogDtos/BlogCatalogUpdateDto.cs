namespace Share.Models.BlogCatalogDtos;

public class BlogCatalogUpdateDto
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(50)]
    public string? Type { get; set; }
    public short? Sort { get; set; }
    public short? Level { get; set; }
    public Guid? ParentId { get; set; }
    public Status? Status { get; set; }
    public bool? IsDeleted { get; set; }

}
