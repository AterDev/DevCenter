using Http.API.Infrastructure;
using Share.Models.ResourceDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源
/// </summary>
public class ResourceController :
    RestControllerBase<IResourceManager>,
    IRestController<Resource, ResourceAddDto, ResourceUpdateDto, ResourceFilterDto, ResourceItemDto>
{
    public ResourceController(
        IUserContext user,
        ILogger<ResourceController> logger,
        IResourceManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<ResourceItemDto>>> FilterAsync(ResourceFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 获取关联的选项
    /// </summary>
    /// <returns></returns>
    [HttpGet("selection")]
    public async Task<ActionResult<ResourceSelectDataDto>> GetSelectionDataAsync()
    {
        return await manager.GetRelationSelectDataAsync();
    }

    [HttpGet]
    public async Task<ActionResult<List<Resource>>> GetAllResourcesAsync()
    {
        return await manager.GetAllResourcesAsync(_user.UserId!.Value);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Resource>> AddAsync(ResourceAddDto form)
    {
        var entity = form.MapTo<ResourceAddDto, Resource>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Resource?>> UpdateAsync([FromRoute] Guid id, ResourceUpdateDto form)
    {
        var current = await manager.GetCurrent(id);
        return current == null ? (ActionResult<Resource?>)NotFound() : (ActionResult<Resource?>)await manager.UpdateAsync(current, form);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Resource?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<Resource>(u => u.Id == id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Resource?>> DeleteAsync([FromRoute] Guid id)
    {
        var entity = await manager.GetCurrent(id);
        return entity == null ? (ActionResult<Resource?>)NotFound() : (ActionResult<Resource?>)await manager.DeleteAsync(entity);
    }
}