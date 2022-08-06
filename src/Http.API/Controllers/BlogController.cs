using Http.API.Infrastructure;
using Share.Models.BlogDtos;
namespace Http.API.Controllers;

/// <summary>
/// 博客
/// </summary>
public class BlogController :
    RestControllerBase<BlogManager>,
    IRestController<Blog, BlogAddDto, BlogUpdateDto, BlogFilterDto, BlogItemDto>
{
    public BlogController(
        IUserContext user,
        ILogger<BlogController> logger,
        BlogManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<BlogItemDto>>> FilterAsync(BlogFilterDto filter)
    {
        return await manager.FilterAsync<BlogItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Blog>> AddAsync(BlogAddDto form)
    {
        var entity = form.MapTo<BlogAddDto, Blog>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Blog?>> UpdateAsync([FromRoute] Guid id, BlogUpdateDto form)
    {
        var user = await manager.GetCurrent(id);
        return user == null ? (ActionResult<Blog?>)NotFound() : (ActionResult<Blog?>)await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Blog?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<Blog>(u => u.Id == id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Blog?>> DeleteAsync([FromRoute] Guid id)
    {
        var entity = await manager.GetCurrent(id);
        if (entity == null) return NotFound();
        return await manager.DeleteAsync(entity);
    }
}