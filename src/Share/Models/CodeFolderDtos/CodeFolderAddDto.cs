namespace Share.Models.CodeFolderDtos;
/// <summary>
/// 代码目录
/// </summary>
public class CodeFolderAddDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public Guid ParentId { get; set; } = default!;

}
