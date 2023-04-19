using Share.Models.GitLabCommitDtos;
using Application.Implement;
using Application.Interface;
using Application.IManager;

namespace Application.Manager;

public class GitLabCommitManager : DomainManagerBase<GitLabCommit, GitLabCommitUpdateDto, GitLabCommitFilterDto, GitLabCommitItemDto>, IGitLabCommitManager
{

    private readonly IUserContext _userContext;
    public GitLabCommitManager(
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
    public Task<GitLabCommit> CreateNewEntityAsync(GitLabCommitAddDto dto)
    {
        var entity = dto.MapTo<GitLabCommitAddDto, GitLabCommit>();
        Command.Db.Entry(entity).Property("UserId").CurrentValue = dto.UserId;
        // or entity.UserId = dto.UserId;
        Command.Db.Entry(entity).Property("ProjectId").CurrentValue = dto.ProjectId;
        // or entity.ProjectId = dto.ProjectId;
        // other required props
        return Task.FromResult(entity);
    }

    public override async Task<GitLabCommit> UpdateAsync(GitLabCommit entity, GitLabCommitUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<GitLabCommitItemDto>> FilterAsync(GitLabCommitFilterDto filter)
    {
        // https://github.com/AterDev/ater.web/blob/56542e5653ee795855705e43482e64df0ee8383d/templates/apistd/src/Core/Utils/Extensions.cs#L82
        Queryable = Queryable
            .WhereNotNull(filter.Name, q => q.Name == filter.Name)
            .WhereNotNull(filter.UserId, q => q.User.Id == filter.UserId)
            .WhereNotNull(filter.ProjectId, q => q.Project.Id == filter.ProjectId);
        // TODO: custom filter conditions
        return await Query.FilterAsync<GitLabCommitItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<GitLabCommit?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
