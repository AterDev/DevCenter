namespace Share.Models.CodeSnippetDtos;
/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetFilterDto : FilterBase
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(20)]
    public string? Format { get; set; }

}
