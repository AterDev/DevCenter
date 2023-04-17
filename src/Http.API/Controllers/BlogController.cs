using Http.API.Infrastructure;
using Share.Models.BlogDtos;
namespace Http.API.Controllers;

/// <summary>
/// 博客
/// </summary>
public class BlogController :
    RestControllerBase<IBlogManager>,
    IRestController<Blog, BlogAddDto, BlogUpdateDto, BlogFilterDto, BlogItemDto>
{
    public BlogController(
        IUserContext user,
        ILogger<BlogController> logger,
        IBlogManager manager
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
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Blog>> AddAsync(BlogAddDto form)
    {
        Blog entity = form.MapTo<BlogAddDto, Blog>();
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
        Blog? user = await manager.GetCurrentAsync(id);
        return user == null ? (ActionResult<Blog?>)NotFound() : (ActionResult<Blog?>)await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Blog?>> GetDetailAsync([FromRoute] Guid id)
    {
        Blog? res = await manager.FindAsync<Blog>(u => u.Id == id);
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
        Blog? entity = await manager.GetCurrentAsync(id);
        return entity == null ? (ActionResult<Blog?>)NotFound() : (ActionResult<Blog?>)await manager.DeleteAsync(entity);
    }
}