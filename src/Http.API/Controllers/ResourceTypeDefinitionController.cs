using Http.API.Infrastructure;
using Share.Models.ResourceTypeDefinitionDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源类型的定义
/// </summary>
public class ResourceTypeDefinitionController :
    RestControllerBase<ResourceTypeDefinitionManager>,
    IRestController<ResourceTypeDefinition, ResourceTypeDefinitionAddDto, ResourceTypeDefinitionUpdateDto, ResourceTypeDefinitionFilterDto, ResourceTypeDefinitionItemDto>
{
    public ResourceTypeDefinitionController(
        IUserContext user,
        ILogger<ResourceTypeDefinitionController> logger,
        ResourceTypeDefinitionManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<ResourceTypeDefinitionItemDto>>> FilterAsync(ResourceTypeDefinitionFilterDto filter)
    {
        return await manager.FilterAsync<ResourceTypeDefinitionItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ResourceTypeDefinition>> AddAsync(ResourceTypeDefinitionAddDto form)
    {
        var entity = form.MapTo<ResourceTypeDefinitionAddDto, ResourceTypeDefinition>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<ResourceTypeDefinition?>> UpdateAsync([FromRoute] Guid id, ResourceTypeDefinitionUpdateDto form)
    {
        var user = await manager.GetCurrent(id);
        if (user == null) return NotFound();
        return await manager.UpdateAsync(user, form);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ResourceTypeDefinition?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync(id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ResourceTypeDefinition?>> DeleteAsync([FromRoute] Guid id)
    {
        var entity = await manager.GetCurrent(id);
        if (entity == null) return NotFound();
        return await manager.DeleteAsync(entity);
    }
}