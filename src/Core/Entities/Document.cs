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
    public string FileName { get; set; } = default!;

    /// <summary>
    /// 文件类型
    /// </summary>
    [MaxLength(20)]
    public string Ext { get; set; } = default!;

    /// <summary>
    /// 文件路径
    /// </summary>
    [MaxLength(200)]
    public string FilePath { get; set; } = default!;

    public DocFolder? Folder { get; set; }
}
