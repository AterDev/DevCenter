namespace Core.Entities.Code;

/// <summary>
/// 模型库
/// </summary>
public class CodeLibrary : EntityBase
{
    /// <summary>
    /// 库命名空间
    /// </summary>
    [MaxLength(100)]
    public string Namespace { get; set; } = null!;
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }
    /// <summary>
    /// 库类型
    /// </summary>
    public LibraryType Type { get; set; } = LibraryType.Code;
    /// <summary>
    /// 是否有效
    /// </summary>
    public bool IsValid { get; set; } = true;
    /// <summary>
    /// 是否公开
    /// </summary>
    public bool IsPublic { get; set; } = false;
    public User User { get; set; } = null!;
    public List<CodeSnippet>? Snippets { get; set; }
}

public enum LibraryType
{
    /// <summary>
    /// 代码
    /// </summary>
    Code,
    /// <summary>
    /// 脚本
    /// </summary>
    Script,
    /// <summary>
    /// 配置
    /// </summary>
    Config,
    /// <summary>
    /// 运维
    /// </summary>
    DevOps
}