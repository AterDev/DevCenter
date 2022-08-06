using Http.API.Infrastructure;
using Share.Models.RoleDtos;
namespace Http.API.Controllers;

/// <summary>
/// 角色表
/// </summary>
public class RoleController :
    RestControllerBase<RoleManager>,
    IRestController<Role, RoleAddDto, RoleUpdateDto, RoleFilterDto, RoleItemDto>
{
    public RoleController(
        IUserContext user,
        ILogger<RoleController> logger,
        RoleManager manager
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
        return await manager.FilterAsync<RoleItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Role>> AddAsync(RoleAddDto form)
    {
        var entity = form.MapTo<RoleAddDto, Role>();
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
        var current = await manager.GetCurrent(id);
        if (current == null) return NotFound();
        return await manager.UpdateAsync(current, form);
    }

    /// <summary>
    /// 分配资源组
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("resourceGroup")]
    public async Task<ActionResult<bool>> SetResourceGroupsAsync([FromBody] RoleResourceDto dto)
    {
        var current = await manager.GetCurrent(dto.RoleId);
        if (current == null) return NotFound();
        return await manager.SetResourceGroupsAsync(dto);
    }
    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Role?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<Role>(u => u.Id == id);
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
        var entity = await manager.GetCurrent(id);
        if (entity == null) return NotFound();
        return await manager.DeleteAsync(entity);
    }
}