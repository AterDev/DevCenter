namespace Share.Models.PermissionDtos;
/// <summary>
/// 权限添加时请求结构
/// </summary>
public class PermissionAddDto
{
    [MaxLength(30)]
    public string Name { get; set; } = default!;
    /// <summary>
    /// 权限路径
    /// </summary>
    [MaxLength(200)]
    public string? PermissionPath { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public Guid ParentId { get; set; } = default!;

}
