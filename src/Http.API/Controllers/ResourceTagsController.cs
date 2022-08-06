using Share.Models.ResourceTagsDtos;
namespace Http.API.Infrastructure;

/// <summary>
/// 资源标识 
/// </summary>
public class ResourceTagsController :
    RestControllerBase<ResourceTagsManager>,
    IRestController<ResourceTags, ResourceTagsAddDto, ResourceTagsUpdateDto, ResourceTagsFilterDto, ResourceTagsItemDto>
{
    public ResourceTagsController(
        IUserContext user,
        ILogger<ResourceTagsController> logger,
        ResourceTagsManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<ResourceTagsItemDto>>> FilterAsync(ResourceTagsFilterDto filter)
    {
        return await manager.FilterAsync<ResourceTagsItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ResourceTags>> AddAsync(ResourceTagsAddDto form)
    {
        var entity = form.MapTo<ResourceTagsAddDto, ResourceTags>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<ResourceTags?>> UpdateAsync([FromRoute] Guid id, ResourceTagsUpdateDto form)
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
    public async Task<ActionResult<ResourceTags?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<ResourceTags>(u => u.Id == id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ResourceTags?>> DeleteAsync([FromRoute] Guid id)
    {
        return await manager.DeleteAsync(id);
    }
}