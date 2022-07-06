namespace Share.Models.RoleDtos;
/// <summary>
/// 角色更新时请求结构
/// </summary>
public class RoleUpdateDto
{
    /// <summary>
    /// 角色名称
    /// </summary>
    [MaxLength(30)]
    public string? Name { get; set; }
    [MaxLength(30)]
    public string? IdentifyName { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    /// <summary>
    /// 图标
    /// </summary>
    [MaxLength(30)]
    public string? Icon { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
