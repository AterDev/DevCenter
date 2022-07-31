namespace Share.Models.CodeLibraryDtos;
/// <summary>
/// 模型库添加时请求结构
/// </summary>
public class CodeLibraryAddDto
{
    /// <summary>
    /// 库命名空间
    /// </summary>
    [MaxLength(100)]
    public string Namespace { get; set; } = default!;
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }
    /// <summary>
    /// 语言类型
    /// </summary>
    [MaxLength(100)]
    public string? Language { get; set; }
    /// <summary>
    /// 是否有效
    /// </summary>
    public bool IsValid { get; set; } = default!;
    /// <summary>
    /// 是否公开
    /// </summary>
    public bool IsPublic { get; set; } = default!;
    public Guid UserId { get; set; } = default!;
    
}
