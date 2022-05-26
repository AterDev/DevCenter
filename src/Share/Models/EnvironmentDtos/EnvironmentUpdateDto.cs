namespace Share.Models.EnvironmentDtos;
/// <summary>
/// 环境
/// </summary>
public class EnvironmentUpdateDto
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
