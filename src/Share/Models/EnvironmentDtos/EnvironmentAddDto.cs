using Core.Utils;

namespace Share.Models.EnvironmentDtos;
/// <summary>
/// 环境
/// </summary>
public class EnvironmentAddDto
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    [MaxLength(200)]
    public string? Description { get; set; }
    [MaxLength(20)]
    public string? Color { get; set; } = Helper.GetRandColor();

}
