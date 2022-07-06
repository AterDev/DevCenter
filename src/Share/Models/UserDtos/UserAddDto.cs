namespace Share.Models.UserDtos;
/// <summary>
/// 系统用户添加时请求结构
/// </summary>
public class UserAddDto
{
    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(30)]
    public string UserName { get; set; } = default!;
    /// <summary>
    /// 真实姓名
    /// </summary>
    [MaxLength(30)]
    public string? RealName { get; set; }
    /// <summary>
    /// 职位
    /// </summary>
    [MaxLength(30)]
    public string? Position { get; set; }
    [MaxLength(100)]
    public string Email { get; set; } = default!;
    [MaxLength(100)]
    public string? Password { get; set; }
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// 角色id
    /// </summary>
    public List<Guid>? RoleIds { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }

}
