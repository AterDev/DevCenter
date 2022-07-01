using Share.Models.ResourceDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源
/// </summary>
public class ResourceController : RestApiBase<ResourceDataStore, Resource, ResourceAddDto, ResourceUpdateDto, ResourceFilterDto, ResourceItemDto>
{
    public ResourceController(IUserContext user, ILogger<ResourceController> logger, ResourceDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override async Task<ActionResult<PageResult<ResourceItemDto>>> FilterAsync(ResourceFilterDto filter)
    {
        return await base.FilterAsync(filter);
    }

    /// <summary>
    /// 获取关联的选项
    /// </summary>
    /// <returns></returns>
    public async Task<ActionResult<ResourceSelectDataDto>> GetSelectionDataAsync()
    {
        return await _store.GetRelationSelectDataAsync();
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<Resource>> AddAsync(ResourceAddDto form)
    {
        var group = await _store.FindGroupAsync(form.GroupId);
        if (group == null) return BadRequest("不存在的资源组");

        var type = await _store.FindTypeAsync(form.ResourceTypeId);
        if (type == null) return BadRequest("不存在的类型");

        var resource = new Resource()
        {
            Group = group,
            ResourceType = type,
        };
        resource = resource.Merge(form);
        if (form.TagIds != null)
        {
            var tags = await _store.FindTagsAsync(form.TagIds);
            resource.Tags = tags;
        }

        return await base.AddAsync(form);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<Resource?>> UpdateAsync([FromRoute] Guid id, ResourceUpdateDto form)
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
