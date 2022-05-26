namespace Share.Models.EnvironmentDtos;
/// <summary>
/// 环境
/// </summary>
public class EnvironmentFilterDto : FilterBase
{
    [MaxLength(50)]
    public string? Name { get; set; }

}
