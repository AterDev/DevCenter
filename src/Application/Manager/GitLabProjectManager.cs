using Share.Models.GitLabProjectDtos;
using Application.Implement;
using Application.Interface;
using Application.IManager;
using NGitLab;
using Share.Options;
using Microsoft.Extensions.Options;

namespace Application.Manager;

public class GitLabProjectManager : DomainManagerBase<GitLabProject, GitLabProjectUpdateDto, GitLabProjectFilterDto, GitLabProjectItemDto>, IGitLabProjectManager
{
    private readonly IUserContext _userContext;
    private readonly GitLabOption _gitlabOption;
    public GitLabProjectManager(
        DataStoreContext storeContext,
        IUserContext userContext,
        IOptions<GitLabOption> gitlabOption) : base(storeContext)
    {
        _userContext = userContext;
        _gitlabOption = gitlabOption.Value;
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

    /// <summary>
    /// 同步项目
    /// </summary>
    public async Task<bool?> SyncProjectAsync()
    {
        if (string.IsNullOrWhiteSpace(_gitlabOption.PAT) || string.IsNullOrWhiteSpace(_gitlabOption.URL))
        {
            ErrorMessage = "gitlab 配置无效";
        }
        var client = new GitLabClient(_gitlabOption.URL, _gitlabOption.PAT);

        var projects = client.Projects.Get(new NGitLab.Models.ProjectQuery
        {
            PerPage = 999,
        })
            .Select(s => new GitLabProject
            {
                Name = s.Name,
                SourceId = s.Id,
                CreatedTime = s.CreatedAt,
            })
            .ToList();
        var sourceIds = projects.Select(u => u.SourceId).ToList();
        var newIds = Query.Db.Where(s => !sourceIds.Contains(s.SourceId))
            .Select(s => s.SourceId)
            .ToList();
        var newProjects = projects.Where(u => newIds.Contains(u.SourceId)).ToList();
        await Command.Db.AddRangeAsync(newProjects);
        return await SaveChangesAsync() > 0;
    }


    public override async Task<GitLabProject> UpdateAsync(GitLabProject entity, GitLabProjectUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<GitLabProjectItemDto>> FilterAsync(GitLabProjectFilterDto filter)
    {
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
