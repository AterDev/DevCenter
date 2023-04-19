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
    public async Task<ActionResult<GitLabCommit?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync(id);
        return (res == null) ? NotFound() : res;
    }

    [AllowAnonymous]
    [HttpGet("sync/users")]
    public List<GitLabUser>? SyncUsers()
    {
        _gitLabUserManager.SyncUserAsync();
        return default;
    }
}