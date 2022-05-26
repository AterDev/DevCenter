namespace Share.Models.DocFolderDtos;
/// <summary>
/// 文档目录
/// </summary>
public class DocFolderFilterDto : FilterBase
{
    [MaxLength(100)]
    public string? Name { get; set; }
    public Guid? ParentId { get; set; } = default!;

}
