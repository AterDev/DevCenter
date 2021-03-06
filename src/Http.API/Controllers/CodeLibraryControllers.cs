using Share.Models.CodeLibraryDtos;
namespace Http.API.Infrastructure;

/// <summary>
/// 模型库
/// </summary>
public class CodeLibraryControllers :
    RestControllerBase<CodeLibraryManager>,
    IRestController<CodeLibrary, CodeLibraryAddDto, CodeLibraryUpdateDto, CodeLibraryFilterDto, CodeLibraryItemDto>
{
    public CodeLibraryControllers(
        IUserContext user,
        ILogger<CodeLibraryControllers> logger,
        CodeLibraryManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<CodeLibraryItemDto>>> FilterAsync(CodeLibraryFilterDto filter)
    {
        return await manager.FilterAsync<CodeLibraryItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<CodeLibrary>> AddAsync(CodeLibraryAddDto form)
    {
        var entity = form.MapTo<CodeLibraryAddDto, CodeLibrary>();
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<CodeLibrary?>> UpdateAsync([FromRoute] Guid id, CodeLibraryUpdateDto form)
    {
        var user = await manager.GetCurrent(id);
        if (user == null) return NotFound();
        return await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CodeLibrary?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<CodeLibrary>(u => u.Id == id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<CodeLibrary?>> DeleteAsync([FromRoute] Guid id)
    {
        return await manager.DeleteAsync(id);
    }
}