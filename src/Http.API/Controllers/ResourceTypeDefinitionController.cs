
using Share.Models.ResourceTypeDefinitionDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源类型的定义
/// </summary>
public class ResourceTypeDefinitionController : RestApiBase<ResourceTypeDefinitionDataStore, ResourceTypeDefinition, ResourceTypeDefinitionAddDto, ResourceTypeDefinitionUpdateDto, ResourceTypeDefinitionFilterDto, ResourceTypeDefinitionItemDto>
{
    private readonly ResourceAttributeDefineDataStore attributeDataStore;

    public ResourceTypeDefinitionController(
        IUserContext user,
        ILogger<ResourceTypeDefinitionController> logger,
        ResourceTypeDefinitionDataStore store,
        ResourceAttributeDefineDataStore attributeDefineDataStore
        ) : base(user, logger, store)
    {
        this.attributeDataStore = attributeDefineDataStore;
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override async Task<ActionResult<PageList<ResourceTypeDefinitionItemDto>>> FilterAsync(ResourceTypeDefinitionFilterDto filter)
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
        var typeDefine = new ResourceTypeDefinition();
        typeDefine = typeDefine.Merge(form);

        if (form.AttributeDefineIds != null)
        {
            var attributeDefines = await attributeDataStore.Db.Where(a => form.AttributeDefineIds.Contains(a.Id)).ToListAsync();
            typeDefine.AttributeDefines = attributeDefines;
        }
        return await _store.AddAsync(typeDefine);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<ResourceTypeDefinition?>> UpdateAsync([FromRoute] Guid id, ResourceTypeDefinitionUpdateDto form)
    {
        var typeDefine = await _store.FindAsync(id);
        if (typeDefine == null) return NotFound("未知type define id");

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
