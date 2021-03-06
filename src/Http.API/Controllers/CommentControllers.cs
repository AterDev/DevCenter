using Share.Models.CommentDtos;
namespace Http.API.Infrastructure;


public class CommentControllers :
    RestControllerBase<CommentManager>,
    IRestController<Comment, CommentAddDto, CommentUpdateDto, CommentFilterDto, CommentItemDto>
{
    public CommentControllers(
        IUserContext user,
        ILogger<CommentControllers> logger,
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
        return await manager.FilterAsync<CommentItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Comment>> AddAsync(CommentAddDto form)
    {
        var entity = form.MapTo<CommentAddDto, Comment>();
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
        var user = await manager.GetCurrent(id);
        if (user == null) return NotFound();
        return await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Comment?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<Comment>(u => u.Id == id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Comment?>> DeleteAsync([FromRoute] Guid id)
    {
        return await manager.DeleteAsync(id);
    }
}