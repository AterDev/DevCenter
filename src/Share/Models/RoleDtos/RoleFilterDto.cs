namespace Share.Models.RoleDtos;
/// <summary>
/// 角色查询筛选
/// </summary>
public class RoleFilterDto : FilterBase
{
    /// <summary>
    /// 角色名称
    /// </summary>
    [MaxLength(30)]
    public string? Name { get; set; }
    [MaxLength(30)]
    public string? IdentifyName { get; set; }

}
