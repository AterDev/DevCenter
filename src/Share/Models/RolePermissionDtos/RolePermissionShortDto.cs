namespace Share.Models.RolePermissionDtos;
/// <summary>
/// 角色权限中间概要
/// </summary>
public class RolePermissionShortDto
{
    public Guid RoleId { get; set; } = default!;
    public Guid PermissionId { get; set; } = default!;
    /// <summary>
    /// 权限类型
    /// </summary>
    public PermissionType PermissionTypeMyProperty { get; set; } = default!;

    public Role Role { get; set; } = default!;
    public Permission Permission { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
