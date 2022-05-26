namespace Share.Models.CodeFolderDtos;
/// <summary>
/// 代码目录
/// </summary>
public class CodeFolderShortDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    public CodeFolder? Parent { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
