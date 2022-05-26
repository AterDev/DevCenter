namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetItemDto
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    [MaxLength(200)]
    public string? Description { get; set; }
    [MaxLength(20)]
    public string Format { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
