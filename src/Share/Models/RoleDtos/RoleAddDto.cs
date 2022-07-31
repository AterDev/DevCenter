namespace Share.Models.RoleDtos;
/// <summary>
/// 角色添加时请求结构
/// </summary>
public class RoleAddDto
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
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(30)]
    public string? Icon { get; set; }

}
