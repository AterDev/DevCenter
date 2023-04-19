using Application.IManager;
using Application.Interface;
using Http.API.Infrastructure;
using Share.Models.BlogTagDtos;
namespace Http.API.Controllers;

/// <summary>
/// 博客标签
/// </summary>
public class BlogTagController :
    RestControllerBase<IBlogTagManager>,
    IRestController<BlogTag, BlogTagAddDto, BlogTagUpdateDto, BlogTagFilterDto, BlogTagItemDto>
{
    public BlogTagController(
        IUserContext user,
        ILogger<BlogTagController> logger,
        IBlogTagManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<BlogTagItemDto>>> FilterAsync(BlogTagFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<BlogTag>> AddAsync(BlogTagAddDto form)
    {
        BlogTag entity = form.MapTo<BlogTagAddDto, BlogTag>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<BlogTag?>> UpdateAsync([FromRoute] Guid id, BlogTagUpdateDto form)
    {
        BlogTag? user = await manager.GetCurrentAsync(id);
        return user == null ? (ActionResult<BlogTag?>)NotFound() : (ActionResult<BlogTag?>)await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<BlogTag?>> GetDetailAsync([FromRoute] Guid id)
    {
        BlogTag? res = await manager.FindAsync<BlogTag>(u => u.Id == id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<BlogTag?>> DeleteAsync([FromRoute] Guid id)
    {
        BlogTag? entity = await manager.GetCurrentAsync(id);
        return entity == null ? (ActionResult<BlogTag?>)NotFound() : (ActionResult<BlogTag?>)await manager.DeleteAsync(entity);
    }
}