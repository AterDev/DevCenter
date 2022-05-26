namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetUpdateDto
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    [MaxLength(20)]
    public string? Format { get; set; }
    [MaxLength(2000)]
    public string? Content { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
