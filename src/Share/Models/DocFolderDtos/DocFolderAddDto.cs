namespace Share.Models.DocFolderDtos;
/// <summary>
/// 文档目录
/// </summary>
public class DocFolderAddDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public Guid ParentId { get; set; } = default!;

}
