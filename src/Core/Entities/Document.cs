namespace Core.Entities;

/// <summary>
/// 文档管理
/// </summary>
public class Document : EntityBase
{
    /// <summary>
    /// 文件名
    /// </summary>
    [MaxLength(100)]
    public required string FileName { get; set; }

    /// <summary>
    /// 文件类型
    /// </summary>
    [MaxLength(20)]
    public required string Ext { get; set; }

    /// <summary>
    /// 文件路径
    /// </summary>
    [MaxLength(200)]
    public required string FilePath { get; set; }

    public DocFolder? Folder { get; set; }
}
