using Application.IManager;
using Application.Interface;
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
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GitLabEvent?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync(id);
        return (res == null) ? NotFound() : res;
    }


    /// <summary>
    /// 同步用户
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("sync/users")]
    public async Task<bool?> SyncUsersAsync()
    {
        return await _gitLabUserManager.SyncUserAsync();
    }

    /// <summary>
    /// 同步项目
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("sync/projects")]
    public async Task<bool?> SyncProjectsAsync()
    {
        return await _gitLabProjectManager.SyncProjectAsync();
    }
}