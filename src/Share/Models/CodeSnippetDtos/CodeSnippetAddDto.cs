namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetAddDto
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    [MaxLength(200)]
    public string? Description { get; set; }
    [MaxLength(20)]
    public string Format { get; set; } = default!;
    [MaxLength(2000)]
    public string? Content { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;

}
