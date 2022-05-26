using Share.Models.CodeSnippetDtos;
namespace Http.API.Controllers;

/// <summary>
/// 代码片段
/// </summary>
public class CodeSnippetController : RestApiBase<CodeSnippetDataStore, CodeSnippet, CodeSnippetAddDto, CodeSnippetUpdateDto, CodeSnippetFilterDto, CodeSnippetItemDto>
{
    public CodeSnippetController(IUserContext user, ILogger<CodeSnippetController> logger, CodeSnippetDataStore store) : base(user, logger, store)
    {
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override async Task<ActionResult<PageResult<CodeSnippetItemDto>>> FilterAsync(CodeSnippetFilterDto filter)
    {
        return await base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<CodeSnippet>> AddAsync(CodeSnippetAddDto form)
    {
        return await base.AddAsync(form);
    }

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override async Task<ActionResult<CodeSnippet?>> UpdateAsync([FromRoute] Guid id, CodeSnippetUpdateDto form)
    {
        return await base.UpdateAsync(id, form);
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    public override async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        return await base.DeleteAsync(id);
    }

    /// <summary>
    /// ⚠ 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public override async Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return await base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
