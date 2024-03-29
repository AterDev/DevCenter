using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

/// <summary>
/// 数据加基础字段模型
/// </summary>
public abstract class EntityBase
{
    [Key]
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    public Status? Status { get; set; } = Models.Status.Default;
    public bool IsDeleted { get; set; } = false;
}

public enum Status
{
    /// <summary>
    /// 默认值 
    /// </summary>
    Default,
    /// <summary>
    /// 已删除
    /// </summary>
    Deleted,
    /// <summary>
    /// 无效
    /// </summary>
    Invalid,
    Valid
}
