using Share.Models.EnvironmentDtos;
namespace Http.API.Infrastructure;

/// <summary>
/// 环境
/// </summary>
public class EnvironmentController :
    RestControllerBase<EnvironmentManager>,
    IRestController<Environment, EnvironmentAddDto, EnvironmentUpdateDto, EnvironmentFilterDto, EnvironmentItemDto>
{
    public EnvironmentController(
        IUserContext user,
        ILogger<EnvironmentController> logger,
        EnvironmentManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<EnvironmentItemDto>>> FilterAsync(EnvironmentFilterDto filter)
    {
        return await manager.FilterAsync<EnvironmentItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Environment>> AddAsync(EnvironmentAddDto form)
    {
        var entity = form.MapTo<EnvironmentAddDto, Environment>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Environment?>> UpdateAsync([FromRoute] Guid id, EnvironmentUpdateDto form)
    {
        var user = await manager.GetCurrent(id);
        if (user == null) return NotFound();
        return await manager.UpdateAsync(user, form);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Environment?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<Environment>(u => u.Id == id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Environment?>> DeleteAsync([FromRoute] Guid id)
    {
        return await manager.DeleteAsync(id);
    }
}