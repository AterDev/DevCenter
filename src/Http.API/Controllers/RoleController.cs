using Share.Models.RoleDtos;
namespace Http.API.Controllers;

/// <summary>
/// 角色表
/// </summary>
public class RoleController : RestApiBase<RoleDataStore, Role, RoleAddDto, RoleUpdateDto, RoleFilterDto, RoleItemDto>
{
    public RoleController(IUserContext user, ILogger<RoleController> logger, RoleDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override async Task<ActionResult<PageList<RoleItemDto>>> FilterAsync(RoleFilterDto filter)
    {
        return await base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<Role>> AddAsync(RoleAddDto form)
    {
        return await base.AddAsync(form);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<Role?>> UpdateAsync([FromRoute] Guid id, RoleUpdateDto form)
    {
        return await base.UpdateAsync(id, form);
    }


    /// <summary>
    /// 分配资源组
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("resourceGroup")]
    public async Task<ActionResult<bool>> SetResourceGroupsAsync([FromBody] RoleResourceDto dto)
    {
        if (await _store.Exist(dto.RoleId))
        {
            return await _store.SetResourceGorupsAsync(dto);
        }
        return NotFound("无效的角色id");
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    public override async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        return await base.DeleteAsync(id);
    }

    /// <summary>
    /// ⚠ 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public override async Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return await base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
