using Share.Models.BlogCatalogDtos;
namespace Http.API.Infrastructure;


public class BlogCatalogControllers :
    RestControllerBase<BlogCatalogManager>,
    IRestController<BlogCatalog, BlogCatalogAddDto, BlogCatalogUpdateDto, BlogCatalogFilterDto, BlogCatalogItemDto>
{
    public BlogCatalogControllers(
        IUserContext user,
        ILogger<BlogCatalogControllers> logger,
        BlogCatalogManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<BlogCatalogItemDto>>> FilterAsync(BlogCatalogFilterDto filter)
    {
        return await manager.FilterAsync<BlogCatalogItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<BlogCatalog>> AddAsync(BlogCatalogAddDto form)
    {
        var entity = form.MapTo<BlogCatalogAddDto, BlogCatalog>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<BlogCatalog?>> UpdateAsync([FromRoute] Guid id, BlogCatalogUpdateDto form)
    {
        var user = await manager.GetCurrent(id);
        if (user == null) return NotFound();
        return await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<BlogCatalog?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<BlogCatalog>(u => u.Id == id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<BlogCatalog?>> DeleteAsync([FromRoute] Guid id)
    {
        return await manager.DeleteAsync(id);
    }
}