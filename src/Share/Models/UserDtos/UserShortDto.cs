namespace Share.Models.UserDtos;
/// <summary>
/// 系统用户概要
/// </summary>
public class UserShortDto
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
    public bool EmailConfirmed { get; set; } = default!;
    // [MaxLength(100)]
    // public string PasswordHash { get; set; }
    // [MaxLength(60)]
    // public string PasswordSalt { get; set; }
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; } = default!;
    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTimeOffset? LastLoginTime { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }
    public Guid Id { get; set; } = default!;

}
