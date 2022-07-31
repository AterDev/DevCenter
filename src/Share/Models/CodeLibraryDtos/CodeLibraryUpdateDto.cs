namespace Share.Models.CodeLibraryDtos;
/// <summary>
/// 模型库更新时请求结构
/// </summary>
public class CodeLibraryUpdateDto
{
    /// <summary>
    /// 库命名空间
    /// </summary>
    [MaxLength(100)]
    public string? Namespace { get; set; }
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
    public bool? IsValid { get; set; }
    /// <summary>
    /// 是否公开
    /// </summary>
    public bool? IsPublic { get; set; }
    public Status? Status { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid? UserId { get; set; } = default!;
    
}
