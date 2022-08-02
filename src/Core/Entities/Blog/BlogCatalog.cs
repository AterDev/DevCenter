using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Blog;

public class BlogCatalog : EntityBase
{
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(50)]
    public string? Type { get; set; }
    public short Sort { get; set; } = 0;
    public short Level { get; set; } = 0;
    /// <summary>
    /// 该目录的文章
    /// </summary>
    public List<Blog>? Blogs { get; set; }
    /// <summary>
    /// 父目录
    /// </summary>
    [ForeignKey("ParentId")]
    public BlogCatalog? Parent { get; set; }
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 子目录
    /// </summary>
    public List<BlogCatalog>? Catalogs { get; set; }

}
