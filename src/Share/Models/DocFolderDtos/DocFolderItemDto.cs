namespace Share.Models.DocFolderDtos;
/// <summary>
/// 文档目录
/// </summary>
public class DocFolderItemDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
