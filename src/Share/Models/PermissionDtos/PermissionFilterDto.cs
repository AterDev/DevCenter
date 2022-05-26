namespace Share.Models.PermissionDtos;
/// <summary>
/// 权限查询筛选
/// </summary>
public class PermissionFilterDto : FilterBase
{
    [MaxLength(30)]
    public string? Name { get; set; }
    public Guid? ParentId { get; set; } = default!;

}
