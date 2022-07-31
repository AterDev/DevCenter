using Core.Entities.Resource;
using Share.Models.ResourceAttributeDefineDtos;
namespace Http.API.Infrastructure;

/// <summary>
/// 资源属性定义
/// </summary>
public class ResourceAttributeDefineController :
    RestControllerBase<ResourceAttributeDefineManager>,
    IRestController<ResourceAttributeDefine, ResourceAttributeDefineAddDto, ResourceAttributeDefineUpdateDto, ResourceAttributeDefineFilterDto, ResourceAttributeDefineItemDto>
{
    public ResourceAttributeDefineController(
        IUserContext user,
        ILogger<ResourceAttributeDefineController> logger,
        ResourceAttributeDefineManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<ResourceAttributeDefineItemDto>>> FilterAsync(ResourceAttributeDefineFilterDto filter)
    {
        return await manager.FilterAsync<ResourceAttributeDefineItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ResourceAttributeDefine>> AddAsync(ResourceAttributeDefineAddDto form)
    {
        var entity = form.MapTo<ResourceAttributeDefineAddDto, ResourceAttributeDefine>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<ResourceAttributeDefine?>> UpdateAsync([FromRoute] Guid id, ResourceAttributeDefineUpdateDto form)
    {
        var user = await manager.GetCurrent(id);
        if (user == null) return NotFound();
        return await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ResourceAttributeDefine?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<ResourceAttributeDefine>(u => u.Id == id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //[ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ResourceAttributeDefine?>> DeleteAsync([FromRoute] Guid id)
    {
        return await manager.DeleteAsync(id);
    }
}