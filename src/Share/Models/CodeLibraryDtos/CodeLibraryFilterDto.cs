namespace Share.Models.CodeLibraryDtos;
/// <summary>
/// 模型库查询筛选
/// </summary>
public class CodeLibraryFilterDto : FilterBase
{
    /// <summary>
    /// 库命名空间
    /// </summary>
    [MaxLength(100)]
    public string? Namespace { get; set; }
    /// <summary>
    /// 是否有效
    /// </summary>
    public bool? IsValid { get; set; }
    /// <summary>
    /// 是否公开
    /// </summary>
    public bool? IsPublic { get; set; }
    public Guid? UserId { get; set; } = default!;
    
}
