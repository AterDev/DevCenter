namespace Share.Models.CodeLibraryDtos;
/// <summary>
/// 模型库列表元素
/// </summary>
public class CodeLibraryItemDto
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
    public LibraryType Type { get; set; } = default!;
    /// <summary>
    /// 是否有效
    /// </summary>
    public bool IsValid { get; set; } = default!;
    /// <summary>
    /// 是否公开
    /// </summary>
    public bool IsPublic { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public Status Status { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;

}
