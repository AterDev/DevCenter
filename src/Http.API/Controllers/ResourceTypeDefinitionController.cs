using Share.Models.ResourceTypeDefinitionDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源类型的定义
/// </summary>
public class ResourceTypeDefinitionController : RestApiBase<ResourceTypeDefinitionDataStore, ResourceTypeDefinition, ResourceTypeDefinitionAddDto, ResourceTypeDefinitionUpdateDto, ResourceTypeDefinitionFilterDto, ResourceTypeDefinitionItemDto>
{
    public ResourceTypeDefinitionController(IUserContext user, ILogger<ResourceTypeDefinitionController> logger, ResourceTypeDefinitionDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override async Task<ActionResult<PageResult<ResourceTypeDefinitionItemDto>>> FilterAsync(ResourceTypeDefinitionFilterDto filter)
    {
        return await base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<ResourceTypeDefinition>> AddAsync(ResourceTypeDefinitionAddDto form)
    {
        return await base.AddAsync(form);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<ResourceTypeDefinition?>> UpdateAsync([FromRoute] Guid id, ResourceTypeDefinitionUpdateDto form)
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
