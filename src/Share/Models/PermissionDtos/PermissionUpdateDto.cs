namespace Share.Models.PermissionDtos;
/// <summary>
/// 权限更新时请求结构
/// </summary>
public class PermissionUpdateDto
{
    [MaxLength(30)]
    public string? Name { get; set; }
    /// <summary>
    /// 权限路径
    /// </summary>
    [MaxLength(200)]
    public string? PermissionPath { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
