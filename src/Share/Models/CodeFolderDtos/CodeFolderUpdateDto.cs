namespace Share.Models.CodeFolderDtos;
/// <summary>
/// 代码目录
/// </summary>
public class CodeFolderUpdateDto
{
    [MaxLength(100)]
    public string? Name { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
