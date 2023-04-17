using Http.API.Infrastructure;
using Share.Models.ResourceDtos;
namespace Http.API.Controllers;

/// <summary>
/// 资源
/// </summary>
public class ResourceController : RestControllerBase<IResourceManager>
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
    /// <param name="groupManager"></param>
    /// <param name="typeDefinitionManager"></param>
    /// <param name="tagsManager"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Resource>> AddAsync(
        ResourceAddDto form,
        [FromServices] IResourceGroupManager groupManager,
        [FromServices] IResourceTypeDefinitionManager typeDefinitionManager,
        [FromServices] IResourceTagsManager tagsManager)
    {
        Resource resource = form.MapTo<ResourceAddDto, Resource>();

        ResourceGroup? group = await groupManager.GetCurrentAsync(form.GroupId);
        if (group == null)
        {
            return BadRequest("不存在的资源组");
        }
        ResourceTypeDefinition? type = await typeDefinitionManager.GetCurrentAsync(form.ResourceTypeId);
        if (type == null)
        {
            return BadRequest("不存在的类型");
        }

        resource.Group = group;
        resource.ResourceType = type;

        if (form.TagIds != null)
        {
            List<ResourceTags> tags = await tagsManager.Command.ListAsync(t => form.TagIds.Contains(t.Id));
            resource.Tags = tags;
        }
        if (form.AttributeAddItem != null)
        {
            List<ResourceAttribute> attributes = new();

            form.AttributeAddItem.ForEach(a =>
            {
                ResourceAttribute attribute = new();
                attribute = attribute.Merge(a);
                attributes.Add(attribute);
            });
            resource.Attributes = attributes;
        }

        return await manager.AddAsync(resource);
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
        Resource? current = await manager.GetCurrentAsync(id);
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
        Resource? res = await manager.FindAsync<Resource>(u => u.Id == id);
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
        Resource? entity = await manager.GetCurrentAsync(id);
        return entity == null ? NotFound() : await manager.DeleteAsync(entity);
    }

}