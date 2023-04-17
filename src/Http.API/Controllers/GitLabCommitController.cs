using Core.Const;
using Share.Models.GitLabCommitDtos;
namespace Http.API.Controllers;

/// <summary>
/// 提交内容
/// </summary>
public class GitLabCommitController : ClientControllerBase<IGitLabCommitManager>
{
    private readonly IGitLabUserManager _gitLabUserManager;
    private readonly IGitLabProjectManager _gitLabProjectManager;

    public GitLabCommitController(
        IUserContext user,
        ILogger<GitLabCommitController> logger,
        IGitLabCommitManager manager,
        IGitLabUserManager gitLabUserManager,
        IGitLabProjectManager gitLabProjectManager
        ) : base(manager, user, logger)
    {
        _gitLabUserManager = gitLabUserManager;
        _gitLabProjectManager = gitLabProjectManager;

    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<GitLabCommitItemDto>>> FilterAsync(GitLabCommitFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<GitLabCommit>> AddAsync(GitLabCommitAddDto dto)
    {
        if (!await _gitLabUserManager.ExistAsync(dto.UserId))
            return NotFound("不存在的{nav.CommentSummary ?? nav.Type}");
        if (!await _gitLabProjectManager.ExistAsync(dto.ProjectId))
            return NotFound("不存在的{nav.CommentSummary ?? nav.Type}");
        var entity = await manager.CreateNewEntityAsync(dto);
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GitLabCommit?>> UpdateAsync([FromRoute] Guid id, GitLabCommitUpdateDto dto)
    {
        var current = await manager.GetOwnedAsync(id);
        if (current == null) return NotFound(ErrorMsg.NotFoundResource);
        if (current.User.Id != dto.UserId)
        {
            var gitLabUser = await _gitLabUserManager.GetCurrentAsync(dto.UserId);
            if (gitLabUser == null) return NotFound("不存在的");
            current.User = gitLabUser;
        }
        if (current.Project.Id != dto.ProjectId)
        {
            var gitLabProject = await _gitLabProjectManager.GetCurrentAsync(dto.ProjectId);
            if (gitLabProject == null) return NotFound("不存在的");
            current.Project = gitLabProject;
        }
        return await manager.UpdateAsync(current, dto);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GitLabCommit?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync(id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<GitLabCommit?>> DeleteAsync([FromRoute] Guid id)
    {
        // 注意删除权限
        var entity = await manager.GetOwnedAsync(id);
        if (entity == null) return NotFound();
        // return Forbid();
        return await manager.DeleteAsync(entity);
    }
}