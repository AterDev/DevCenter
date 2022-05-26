namespace Share.Models.PermissionDtos;
/// <summary>
/// 权限概要
/// </summary>
public class PermissionShortDto
{
    [MaxLength(30)]
    public string Name { get; set; } = default!;
    /// <summary>
    /// 父级权限
    /// </summary>
    public Permission? Parent { get; set; } = default!;
    /// <summary>
    /// 权限路径
    /// </summary>
    [MaxLength(200)]
    public string? PermissionPath { get; set; }
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
