using Http.API.Infrastructure;
using Share.Models.CodeSnippetDtos;
namespace Http.API.Controllers;

/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetController :
    RestControllerBase<CodeSnippetManager>,
    IRestController<CodeSnippet, CodeSnippetAddDto, CodeSnippetUpdateDto, CodeSnippetFilterDto, CodeSnippetItemDto>
{
    public CodeSnippetController(
        IUserContext user,
        ILogger<CodeSnippetController> logger,
        CodeSnippetManager manager
        ) : base(manager, user, logger)
    {
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<CodeSnippetItemDto>>> FilterAsync(CodeSnippetFilterDto filter)
    {
        return await manager.FilterAsync<CodeSnippetItemDto>(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<CodeSnippet>> AddAsync(CodeSnippetAddDto form)
    {
        var entity = form.MapTo<CodeSnippetAddDto, CodeSnippet>();
        var user = await _user.GetUserAsync();
        if (user == null) return NotFound();
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
    public async Task<ActionResult<CodeSnippet?>> UpdateAsync([FromRoute] Guid id, CodeSnippetUpdateDto form)
    {
        var user = await manager.GetCurrent(id);
        if (user == null) return NotFound();
        return await manager.UpdateAsync(user, form);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CodeSnippet?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync<CodeSnippet>(u => u.Id == id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<CodeSnippet?>> DeleteAsync([FromRoute] Guid id)
    {
        return await manager.DeleteAsync(id);
    }
}