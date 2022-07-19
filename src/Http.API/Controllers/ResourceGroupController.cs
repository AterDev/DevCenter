using Share.Models.ResourceGroupDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源组
/// </summary>
public class ResourceGroupController : RestApiBase<ResourceGroupDataStore, ResourceGroup, ResourceGroupAddDto, ResourceGroupUpdateDto, ResourceGroupFilterDto, ResourceGroupItemDto>
{

    private readonly EnvironmentDataStore environmentStore;
    public ResourceGroupController(
        IUserContext user,
        ILogger<ResourceGroupController> logger,
        ResourceGroupDataStore store,
        EnvironmentDataStore environmentDataStore) : base(user, logger, store)
    {
        environmentStore = environmentDataStore;
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override async Task<ActionResult<PageList<ResourceGroupItemDto>>> FilterAsync(ResourceGroupFilterDto filter)
    {
        if (!_user.IsAdmin)
        {
            filter.UserId = _user.UserId;
        }
        return await base.FilterAsync(filter);
    }

    /// <summary>
    /// 获取某角色分配的资源组
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    [HttpGet("role")]
    public async Task<List<ResourceGroupRoleDto>> GetRoleResourceGroupsAsync(Guid? roleId)
    {
        return await _store.GetRoleResourceGroupsAsync(roleId);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<ResourceGroup>> AddAsync(ResourceGroupAddDto form)
    {
        var environment = await environmentStore.FindAsync(form.EnvironmentId);
        if (environment == null) return BadRequest("未找到关联的环境");
        var group = new ResourceGroup();
        group = group.Merge(form);
        group.Environment = environment;
        return await _store.AddAsync(group);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<ResourceGroup?>> UpdateAsync([FromRoute] Guid id, ResourceGroupUpdateDto form)
    {
        return await base.UpdateAsync(id, form);
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
