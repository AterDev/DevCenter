namespace Share.Models.RolePermissionDtos;
/// <summary>
/// 角色权限中间添加时请求结构
/// </summary>
public class RolePermissionAddDto
{
    public Guid RoleId { get; set; } = default!;
    public Guid PermissionId { get; set; } = default!;
    /// <summary>
    /// 权限类型
    /// </summary>
    public PermissionType PermissionTypeMyProperty { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;

}
