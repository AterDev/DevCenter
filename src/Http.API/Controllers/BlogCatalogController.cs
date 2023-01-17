using Http.API.Infrastructure;
using Share.Models.BlogCatalogDtos;
namespace Http.API.Controllers;

/// <summary>
/// 博客目录
/// </summary>
[Route("api/[controller]")]
public class BlogCatalogController :
    RestControllerBase<IBlogCatalogManager>,
    IRestController<BlogCatalog, BlogCatalogAddDto, BlogCatalogUpdateDto, BlogCatalogFilterDto, BlogCatalogItemDto>
{
    public BlogCatalogController(
        IUserContext user,
        ILogger<BlogCatalogController> logger,
        IBlogCatalogManager manager
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
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<BlogCatalog>> AddAsync(BlogCatalogAddDto form)
    {
        BlogCatalog entity = form.MapTo<BlogCatalogAddDto, BlogCatalog>();
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
        BlogCatalog? user = await manager.GetCurrent(id);
        return user == null ? (ActionResult<BlogCatalog?>)NotFound() : (ActionResult<BlogCatalog?>)await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<BlogCatalog?>> GetDetailAsync([FromRoute] Guid id)
    {
        BlogCatalog? res = await manager.FindAsync<BlogCatalog>(u => u.Id == id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<BlogCatalog?>> DeleteAsync([FromRoute] Guid id)
    {
        BlogCatalog? entity = await manager.GetCurrent(id);
        return entity == null ? (ActionResult<BlogCatalog?>)NotFound() : (ActionResult<BlogCatalog?>)await manager.DeleteAsync(entity);
    }
}