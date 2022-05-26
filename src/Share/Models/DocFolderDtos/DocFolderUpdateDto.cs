namespace Share.Models.DocFolderDtos;
/// <summary>
/// 文档目录
/// </summary>
public class DocFolderUpdateDto
{
    [MaxLength(100)]
    public string? Name { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
