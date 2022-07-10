namespace Share.Models.RoleDtos;
public class RoleResourceDto
{
    /// <summary>
    /// 资源组
    /// </summary>
    public List<Guid> GroupIds { get; set; } = default!;
    /// <summary>
    /// 角色id
    /// </summary>
    public Guid RoleId { get; set; } = default!;

}
