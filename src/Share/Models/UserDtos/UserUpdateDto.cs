namespace Share.Models.UserDtos;
/// <summary>
/// 系统用户更新时请求结构
/// </summary>
public class UserUpdateDto
{
    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(30)]
    public string? UserName { get; set; }
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
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    [MaxLength(100)]
    public string? Password { get; set; }
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    public bool? PhoneNumberConfirmed { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    
}
