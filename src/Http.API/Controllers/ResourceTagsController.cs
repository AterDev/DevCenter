using Application.IManager;
using Application.Interface;
using Http.API.Infrastructure;
using Share.Models.ResourceTagsDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源标识 
/// </summary>
public class ResourceTagsController :
    RestControllerBase<IResourceTagsManager>,
    IRestController<ResourceTags, ResourceTagsAddDto, ResourceTagsUpdateDto, ResourceTagsFilterDto, ResourceTagsItemDto>
{
    public ResourceTagsController(
        IUserContext user,
        ILogger<ResourceTagsController> logger,
        IResourceTagsManager manager
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
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ResourceTags>> AddAsync(ResourceTagsAddDto form)
    {
        ResourceTags entity = form.MapTo<ResourceTagsAddDto, ResourceTags>();
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
        ResourceTags? user = await manager.GetCurrentAsync(id);
        return user == null ? (ActionResult<ResourceTags?>)NotFound() : (ActionResult<ResourceTags?>)await manager.UpdateAsync(user, form);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ResourceTags?>> GetDetailAsync([FromRoute] Guid id)
    {
        ResourceTags? res = await manager.FindAsync<ResourceTags>(u => u.Id == id);
        return res == null ? NotFound() : res;
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
        ResourceTags? entity = await manager.GetCurrentAsync(id);
        return entity == null ? (ActionResult<ResourceTags?>)NotFound() : (ActionResult<ResourceTags?>)await manager.DeleteAsync(entity);
    }
}