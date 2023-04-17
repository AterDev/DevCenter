using Share.Models.GitLabCommitDtos;

namespace Http.Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IGitLabCommitManager : IDomainManager<GitLabCommit, GitLabCommitUpdateDto, GitLabCommitFilterDto, GitLabCommitItemDto>
{
	/// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<GitLabCommit?> GetOwnedAsync(Guid id);

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<GitLabCommit> CreateNewEntityAsync(GitLabCommitAddDto dto);
}
