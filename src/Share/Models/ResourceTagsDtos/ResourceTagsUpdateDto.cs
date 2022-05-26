namespace Share.Models.ResourceTagsDtos;
/// <summary>
/// 资源标识 
/// </summary>
public class ResourceTagsUpdateDto
{
    [MaxLength(100)]
    public string? Name { get; set; }
    public string? Color { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }

}
