namespace Share.Models.DocumentDtos;
/// <summary>
/// 文档管理
/// </summary>
public class DocumentUpdateDto
{
    /// <summary>
    /// 文件名
    /// </summary>
    [MaxLength(100)]
    public string? FileName { get; set; }

    /// <summary>
    /// 文件类型
    /// </summary>
    [MaxLength(20)]
    public string? Ext { get; set; }

    /// <summary>
    /// 文件路径
    /// </summary>
    [MaxLength(200)]
    public string? FilePath { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
