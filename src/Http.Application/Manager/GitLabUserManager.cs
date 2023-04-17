using Http.Application.Implement;
using Http.Application.IManager;
using Share.Models.GitLabUserDtos;

namespace Http.Application.Manager;

public class GitLabUserManager : DomainManagerBase<GitLabUser, GitLabUserUpdateDto, GitLabUserFilterDto, GitLabUserItemDto>, IGitLabUserManager
{

    private readonly IUserContext _userContext;
    public GitLabUserManager(
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
    public Task<GitLabUser> CreateNewEntityAsync(GitLabUserAddDto dto)
    {
        var entity = dto.MapTo<GitLabUserAddDto, GitLabUser>();
        // other required props
        return Task.FromResult(entity);
    }

    public override async Task<GitLabUser> UpdateAsync(GitLabUser entity, GitLabUserUpdateDto dto)
    {
      return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<GitLabUserItemDto>> FilterAsync(GitLabUserFilterDto filter)
    {
        // https://github.com/AterDev/ater.web/blob/56542e5653ee795855705e43482e64df0ee8383d/templates/apistd/src/Core/Utils/Extensions.cs#L82
        Queryable = Queryable
            .WhereNotNull(filter.Name, q => q.Name == filter.Name);
        // TODO: custom filter conditions
        return await Query.FilterAsync<GitLabUserItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<GitLabUser?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
