namespace Share.Models.RoleDtos;
/// <summary>
/// 角色列表元素
/// </summary>
public class RoleItemDto
{
    /// <summary>
    /// 角色名称
    /// </summary>
    [MaxLength(30)]
    public string Name { get; set; } = default!;
    [MaxLength(30)]
    public string IdentifyName { get; set; } = default!;
    [MaxLength(200)]
    public string? Description { get; set; }
    public Guid Id { get; set; } = default!;

}
