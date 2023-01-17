using Http.API.Infrastructure;
using Share.Models.ResourceAttributeDefineDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源属性定义
/// </summary>
public class ResourceAttributeDefineController :
    RestControllerBase<IResourceAttributeDefineManager>,
    IRestController<ResourceAttributeDefine, ResourceAttributeDefineAddDto, ResourceAttributeDefineUpdateDto, ResourceAttributeDefineFilterDto, ResourceAttributeDefineItemDto>
{
    public ResourceAttributeDefineController(
        IUserContext user,
        ILogger<ResourceAttributeDefineController> logger,
        IResourceAttributeDefineManager manager
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
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize("Admin")]
    public async Task<ActionResult<ResourceAttributeDefine>> AddAsync(ResourceAttributeDefineAddDto form)
    {
        ResourceAttributeDefine entity = form.MapTo<ResourceAttributeDefineAddDto, ResourceAttributeDefine>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize("Admin")]
    public async Task<ActionResult<ResourceAttributeDefine?>> UpdateAsync([FromRoute] Guid id, ResourceAttributeDefineUpdateDto form)
    {
        ResourceAttributeDefine? user = await manager.GetCurrent(id);
        return user == null ? (ActionResult<ResourceAttributeDefine?>)NotFound() : (ActionResult<ResourceAttributeDefine?>)await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ResourceAttributeDefine?>> GetDetailAsync([FromRoute] Guid id)
    {
        ResourceAttributeDefine? res = await manager.FindAsync<ResourceAttributeDefine>(u => u.Id == id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //[ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    [Authorize("Admin")]
    public async Task<ActionResult<ResourceAttributeDefine?>> DeleteAsync([FromRoute] Guid id)
    {
        ResourceAttributeDefine? entity = await manager.GetCurrent(id);
        return entity == null ? (ActionResult<ResourceAttributeDefine?>)NotFound() : (ActionResult<ResourceAttributeDefine?>)await manager.DeleteAsync(entity);
    }
}