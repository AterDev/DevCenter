using Application.Interface;
using Share.Models.GitLabProjectDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IGitLabProjectManager : IDomainManager<GitLabProject, GitLabProjectUpdateDto, GitLabProjectFilterDto, GitLabProjectItemDto>
{
    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<GitLabProject?> GetOwnedAsync(Guid id);

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<GitLabProject> CreateNewEntityAsync(GitLabProjectAddDto dto);
    Task<bool?> SyncProjectAsync();
}
