namespace Share.Models.CodeFolderDtos;
/// <summary>
/// 代码目录
/// </summary>
public class CodeFolderFilterDto : FilterBase
{
    [MaxLength(100)]
    public string? Name { get; set; }
    public Guid? ParentId { get; set; } = default!;

}
