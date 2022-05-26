namespace Share.Models.DocumentDtos;
/// <summary>
/// 文档管理
/// </summary>
public class DocumentItemDto
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
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
