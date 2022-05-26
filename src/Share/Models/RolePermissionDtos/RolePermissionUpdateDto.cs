namespace Share.Models.RolePermissionDtos;
/// <summary>
/// 角色权限中间更新时请求结构
/// </summary>
public class RolePermissionUpdateDto
{
    public Guid? RoleId { get; set; }
    public Guid? PermissionId { get; set; }
    /// <summary>
    /// 权限类型
    /// </summary>
    public PermissionType? PermissionTypeMyProperty { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
