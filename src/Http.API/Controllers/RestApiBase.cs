using Application.Implement;
using Application.Interface;
using Http.API.Interface;
using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace Http.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize("User")]
public class RestApiBase<TDataStore, TEntity, TAdd, TUpdate, TFilter, TItem>
    : ControllerBase, IRestApiBase<TEntity, TAdd, TUpdate, TFilter, TItem, Guid>
    where TDataStore : DataStoreBase<ContextBase, TEntity, TUpdate, TFilter, TItem>
    where TEntity : EntityBase
    where TFilter : FilterBase
{
    protected readonly ILogger _logger;
    protected readonly TDataStore _store;
    protected readonly IUserContext _user;
    protected readonly DataStoreContext _storeContext;

    public RestApiBase(IUserContext user, ILogger logger, TDataStore store)
    {
        _user = user;
        _store = store;
        _logger = logger;
        //_storeContext = storeContext;
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<ActionResult<TEntity>> AddAsync(TAdd form)
    {
        TEntity data = (TEntity)Activator.CreateInstance(typeof(TEntity))!;
        data = data.Merge(form);
        return await _store.AddAsync(data);
    }


    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public virtual async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        return _store.Any(d => d.Id == id) ? (ActionResult<bool>)await _store.DeleteAsync(id) : (ActionResult<bool>)NotFound();
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public virtual async Task<ActionResult<PageList<TItem>>> FilterAsync(TFilter filter)
    {
        return await _store.FindWithPageAsync(filter);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntity?>> GetDetailAsync([FromRoute] Guid id)
    {
        TEntity? data = await _store.FindAsync(id);
        return data == null ? (ActionResult<TEntity?>)NotFound() : (ActionResult<TEntity?>)data;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public virtual async Task<ActionResult<TEntity?>> UpdateAsync([FromRoute] Guid id, TUpdate form)
    {
        return _store.Exist(id).Result ? (ActionResult<TEntity?>)await _store.UpdateAsync(id, form) : (ActionResult<TEntity?>)NotFound();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [HttpDelete]
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        return await _store.BatchDeleteAsync(ids);
    }

    /// <summary>
    /// 批量更新
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [HttpPut]
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<int> BatchUpdateAsync([FromBody] BatchUpdate<TUpdate> data)
    {
        return await _store.BatchUpdateAsync(data.Ids, data.UpdateDto);
    }

    /// <summary>
    /// 404返回格式处理
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override NotFoundObjectResult NotFound([ActionResultObjectValue] object? value)
    {
        var res = new {
            Title = "访问的资源不存在",
            Detail = value?.ToString(),
            Status = 404,
            TraceId = HttpContext.TraceIdentifier
        };
        return base.NotFound(res);
    }

    /// <summary>
    /// 409返回格式处理
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public override ConflictObjectResult Conflict([ActionResultObjectValue] object? error)
    {
        var res = new {
            Title = "重复的资源",
            Detail = error?.ToString(),
            Status = 409,
            TraceId = HttpContext.TraceIdentifier
        };
        return base.Conflict(res);
    }
}
