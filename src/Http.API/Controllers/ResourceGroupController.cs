using Application.IManager;
using Application.Interface;
using Http.API.Infrastructure;
using Share.Models.ResourceGroupDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源组
/// </summary>
public class ResourceGroupController :
    RestControllerBase<IResourceGroupManager>,
    IRestController<ResourceGroup, ResourceGroupAddDto, ResourceGroupUpdateDto, ResourceGroupFilterDto, ResourceGroupItemDto>
{
    public ResourceGroupController(
        IUserContext user,
        ILogger<ResourceGroupController> logger,
        IResourceGroupManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<ResourceGroupItemDto>>> FilterAsync(ResourceGroupFilterDto filter)
    {
        if (!_user.IsAdmin)
        {
            filter.UserId = _user.UserId;
        }
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 资源组列表
    /// </summary>
    /// <returns></returns>
    [HttpPost("list")]
    public async Task<List<ResourceGroupItemDto>> GetList()
    {
        return await manager.GetList();
    }

    /// <summary>
    /// 获取某角色分配的资源组
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    [HttpGet("role")]
    public async Task<List<ResourceGroupRoleDto>> GetRoleResourceGroupsAsync(Guid? roleId)
    {
        return await manager.GetRoleResourceGroupsAsync(roleId);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize("Admin")]
    public async Task<ActionResult<ResourceGroup>> AddAsync(ResourceGroupAddDto form)
    {
        Environment? environment = await manager.Stores.EnvironmentCommand.FindAsync(e => e.Id == form.EnvironmentId);
        if (environment == null)
        {
            return BadRequest("未找到关联的环境");
        }
        ResourceGroup entity = form.MapTo<ResourceGroupAddDto, ResourceGroup>();
        entity.Environment = environment;
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<ResourceGroup?>> UpdateAsync([FromRoute] Guid id, ResourceGroupUpdateDto form)
    {
        ResourceGroup? group = await manager.GetCurrentAsync(id);
        return group == null ? NotFound() : await manager.UpdateAsync(group, form);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ResourceGroup?>> GetDetailAsync([FromRoute] Guid id)
    {
        ResourceGroup? res = await manager.FindAsync(id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ResourceGroup?>> DeleteAsync([FromRoute] Guid id)
    {
        ResourceGroup? entity = await manager.GetCurrentAsync(id);
        return entity == null ? NotFound() : await manager.DeleteAsync(entity);
    }
}