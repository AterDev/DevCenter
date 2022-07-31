using Core.Entities.Resource;
using Share.Models.ResourceAttributeDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源属性值 
/// </summary>
public class ResourceAttributeController : RestApiBase<ResourceAttributeDataStore, ResourceAttribute, ResourceAttributeAddDto, ResourceAttributeUpdateDto, ResourceAttributeFilterDto, ResourceAttributeItemDto>
{
    public ResourceAttributeController(IUserContext user, ILogger<ResourceAttributeController> logger, ResourceAttributeDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override async Task<ActionResult<PageList<ResourceAttributeItemDto>>> FilterAsync(ResourceAttributeFilterDto filter)
    {
        return await base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<ResourceAttribute>> AddAsync(ResourceAttributeAddDto form)
    {
        return await base.AddAsync(form);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<ResourceAttribute?>> UpdateAsync([FromRoute] Guid id, ResourceAttributeUpdateDto form)
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
