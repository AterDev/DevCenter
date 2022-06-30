namespace Share.Models.ResourceGroupDtos;
/// <summary>
/// 资源组
/// </summary>
public class ResourceGroupAddDto
{
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(400)]
    public string? Descriptioin { get; set; }
    public Guid EnvironmentId { get; set; } = default!;

}
