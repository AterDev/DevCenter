using Application.IManager;
using Application.Interface;
using Http.API.Infrastructure;
using Share.Models.RoleDtos;
namespace Http.API.Controllers;

/// <summary>
/// 角色表
/// </summary>
public class RoleController :
    RestControllerBase<IRoleManager>,
    IRestController<Role, RoleAddDto, RoleUpdateDto, RoleFilterDto, RoleItemDto>
{
    public RoleController(
        IUserContext user,
        ILogger<RoleController> logger,
        IRoleManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<RoleItemDto>>> FilterAsync(RoleFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Role>> AddAsync(RoleAddDto form)
    {
        Role entity = form.MapTo<RoleAddDto, Role>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Role?>> UpdateAsync([FromRoute] Guid id, RoleUpdateDto form)
    {
        Role? current = await manager.GetCurrentAsync(id);
        return current == null ? (ActionResult<Role?>)NotFound() : (ActionResult<Role?>)await manager.UpdateAsync(current, form);
    }

    /// <summary>
    /// 分配资源组
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("resourceGroup")]
    public async Task<ActionResult<bool>> SetResourceGroupsAsync([FromBody] RoleResourceDto dto)
    {
        Role? current = await manager.GetCurrentAsync(dto.RoleId);
        return current == null ? (ActionResult<bool>)NotFound() : (ActionResult<bool>)await manager.SetResourceGroupsAsync(dto);
    }
    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Role?>> GetDetailAsync([FromRoute] Guid id)
    {
        Role? res = await manager.FindAsync<Role>(u => u.Id == id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Role?>> DeleteAsync([FromRoute] Guid id)
    {
        Role? entity = await manager.GetCurrentAsync(id);
        return entity == null ? (ActionResult<Role?>)NotFound() : (ActionResult<Role?>)await manager.DeleteAsync(entity);
    }
}