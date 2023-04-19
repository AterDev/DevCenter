using Share.Models.GitLabProjectDtos;
using Application.Implement;
using Application.Interface;
using Application.IManager;

namespace Application.Manager;

public class GitLabProjectManager : DomainManagerBase<GitLabProject, GitLabProjectUpdateDto, GitLabProjectFilterDto, GitLabProjectItemDto>, IGitLabProjectManager
{

    private readonly IUserContext _userContext;
    public GitLabProjectManager(
        DataStoreContext storeContext,
        IUserContext userContext) : base(storeContext)
    {

        _userContext = userContext;
    }

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<GitLabProject> CreateNewEntityAsync(GitLabProjectAddDto dto)
    {
        var entity = dto.MapTo<GitLabProjectAddDto, GitLabProject>();
        // other required props
        return Task.FromResult(entity);
    }

    public override async Task<GitLabProject> UpdateAsync(GitLabProject entity, GitLabProjectUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<GitLabProjectItemDto>> FilterAsync(GitLabProjectFilterDto filter)
    {
        // https://github.com/AterDev/ater.web/blob/56542e5653ee795855705e43482e64df0ee8383d/templates/apistd/src/Core/Utils/Extensions.cs#L82
        Queryable = Queryable
            .WhereNotNull(filter.Name, q => q.Name == filter.Name);
        // TODO: custom filter conditions
        return await Query.FilterAsync<GitLabProjectItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<GitLabProject?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
