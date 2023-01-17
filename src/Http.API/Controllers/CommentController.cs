using Http.API.Infrastructure;
using Share.Models.CommentDtos;
namespace Http.API.Controllers;

/// <summary>
/// 博客评论
/// </summary>
public class CommentController :
    RestControllerBase<CommentManager>,
    IRestController<Comment, CommentAddDto, CommentUpdateDto, CommentFilterDto, CommentItemDto>
{
    public CommentController(
        IUserContext user,
        ILogger<CommentController> logger,
        CommentManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<CommentItemDto>>> FilterAsync(CommentFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Comment>> AddAsync(CommentAddDto form)
    {
        Comment entity = form.MapTo<CommentAddDto, Comment>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Comment?>> UpdateAsync([FromRoute] Guid id, CommentUpdateDto form)
    {
        Comment? user = await manager.GetCurrent(id);
        return user == null ? (ActionResult<Comment?>)NotFound() : (ActionResult<Comment?>)await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Comment?>> GetDetailAsync([FromRoute] Guid id)
    {
        Comment? res = await manager.FindAsync<Comment>(u => u.Id == id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Comment?>> DeleteAsync([FromRoute] Guid id)
    {
        Comment? entity = await manager.GetCurrent(id);
        return entity == null ? (ActionResult<Comment?>)NotFound() : (ActionResult<Comment?>)await manager.DeleteAsync(entity);
    }
}