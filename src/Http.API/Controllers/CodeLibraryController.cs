using Http.API.Infrastructure;
using Share.Models.CodeLibraryDtos;
namespace Http.API.Controllers;

/// <summary>
/// 模型库
/// </summary>
public class CodeLibraryController :
    RestControllerBase<ICodeLibraryManager>,
    IRestController<CodeLibrary, CodeLibraryAddDto, CodeLibraryUpdateDto, CodeLibraryFilterDto, CodeLibraryItemDto>
{
    public CodeLibraryController(
        IUserContext user,
        ILogger<CodeLibraryController> logger,
        ICodeLibraryManager manager
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
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<CodeLibrary>> AddAsync(CodeLibraryAddDto form)
    {
        CodeLibrary entity = form.MapTo<CodeLibraryAddDto, CodeLibrary>();
        User? user = await _user.GetUserAsync();
        if (user == null)
        {
            return NotFound();
        }
        entity.User = user;
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
        CodeLibrary? user = await manager.GetCurrentAsync(id);
        return user == null ? (ActionResult<CodeLibrary?>)NotFound() : (ActionResult<CodeLibrary?>)await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CodeLibrary?>> GetDetailAsync([FromRoute] Guid id)
    {
        CodeLibrary? res = await manager.FindAsync<CodeLibrary>(u => u.Id == id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<CodeLibrary?>> DeleteAsync([FromRoute] Guid id)
    {
        CodeLibrary? entity = await manager.GetCurrentAsync(id);
        return entity == null ? (ActionResult<CodeLibrary?>)NotFound() : (ActionResult<CodeLibrary?>)await manager.DeleteAsync(entity);
    }
}