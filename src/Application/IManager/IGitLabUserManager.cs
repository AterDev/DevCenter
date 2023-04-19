using Application.Interface;
using Share.Models.GitLabUserDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IGitLabUserManager : IDomainManager<GitLabUser, GitLabUserUpdateDto, GitLabUserFilterDto, GitLabUserItemDto>
{
    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<GitLabUser?> GetOwnedAsync(Guid id);

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<GitLabUser> CreateNewEntityAsync(GitLabUserAddDto dto);
    Task<bool?> SyncUserAsync();
}
