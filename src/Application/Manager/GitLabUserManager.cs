using Share.Models.GitLabUserDtos;
using Application.Implement;
using Application.Interface;
using Application.IManager;
using NGitLab;
using Microsoft.Extensions.Options;
using Share.Options;

namespace Application.Manager;

public class GitLabUserManager : DomainManagerBase<GitLabUser, GitLabUserUpdateDto, GitLabUserFilterDto, GitLabUserItemDto>, IGitLabUserManager
{
    private readonly IUserContext _userContext;
    private readonly GitLabOption _gitlabOption;

    public GitLabUserManager(
        DataStoreContext storeContext,
        IUserContext userContext,
        IOptions<GitLabOption> options) : base(storeContext)
    {
        _userContext = userContext;
        _gitlabOption = options.Value;
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

    /// <summary>
    /// 同步用户
    /// </summary>
    public async Task<bool?> SyncUserAsync()
    {
        if (string.IsNullOrWhiteSpace(_gitlabOption.PAT) || string.IsNullOrWhiteSpace(_gitlabOption.URL))
        {
            ErrorMessage = "gitlab 配置无效";
        }
        var client = new GitLabClient(_gitlabOption.URL, _gitlabOption.PAT);

        var users = client.Users.All.Where(u => u.State == "active")
            .Select(s => new GitLabUser
            {
                Email = s.Email,
                Name = s.Name,
                SourceId = s.Id,
                CreatedTime = s.CreatedAt,
                AvatarUrl = s.AvatarURL
            })
            .ToList();
        // select database not exist ids
        var sourceIds = users.Select(u => u.SourceId).ToList();
        var newIds = Query.Db.Where(s => !sourceIds.Contains(s.SourceId))
            .Select(s => s.SourceId)
            .ToList();
        var newUser = users.Where(u => newIds.Contains(u.SourceId)).ToList();
        await Command.Db.AddRangeAsync(newUser);
        return await SaveChangesAsync() > 0;
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
