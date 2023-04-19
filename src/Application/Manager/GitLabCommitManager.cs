using Share.Models.GitLabCommitDtos;
using Application.Implement;
using Application.Interface;
using Application.IManager;
using NGitLab;
using Share.Options;
using Microsoft.Extensions.Options;

namespace Application.Manager;

public class GitLabCommitManager : DomainManagerBase<GitLabCommit, GitLabCommitUpdateDto, GitLabCommitFilterDto, GitLabCommitItemDto>, IGitLabCommitManager
{
    private readonly IUserContext _userContext;
    private readonly GitLabOption _gitlabOption;
    public GitLabCommitManager(
        DataStoreContext storeContext,
        IOptions<GitLabOption> gitlabOption,
        IUserContext userContext) : base(storeContext)
    {
        _userContext = userContext;
        _gitlabOption = gitlabOption.Value;
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

    /// <summary>
    /// 同步commit
    /// </summary>
    /// <param name="projectId"></param>
    /// <returns></returns>
    public async Task<bool> SyncProjectCommitAsync(int projectId)
    {
        var project = await Stores.GitLabProjectQuery.Db.SingleOrDefaultAsync(s => s.SourceId == projectId);
        if (project != null)
        {
            var client = new GitLabClient(_gitlabOption.URL, _gitlabOption.PAT);
            var exist = Query.Db.Any(q => q.Project.Id == project.Id);
            // get all users and project from database
            var users = await Stores.GitLabUserQuery.Db.ToListAsync();

            if (exist)
            {
                // increment update
                var commits = client.GetRepository(projectId)
                    .GetCommits(new GetCommitsRequest
                    {
                        PerPage = 20,
                        MaxResults = 20,
                    }).ToList();
                // select commit not exist in database
                var newCommitIds = Query.Db.Where(q => !commits.Select(c => c.Id.ToString()).ToList().Contains(q.SourceId))
                    .Select(q => q.SourceId)
                    .ToList();

                var newCommits = commits.Where(w => newCommitIds.Contains(w.Id.ToString()))
                    .Select(s => new GitLabCommit
                    {
                        Name = s.Title,
                        Message = s.Message,
                        SourceId = s.Id.ToString(),
                        CreatedTime = s.CreatedAt,
                        User = users.FirstOrDefault(f => f.Email == s.AuthorEmail)!,
                        Project = project
                    }).ToList();
                await Command.Db.AddRangeAsync(newCommits);
                return await SaveChangesAsync() > 0;
            }
            else
            {
                // 全量更新
                var commits = client.GetRepository(projectId).GetCommits(new GetCommitsRequest
                {
                    //PerPage = 2000,
                    MaxResults = 2000,
                });
                var newCommits = commits.Select(s => new GitLabCommit
                {
                    Name = s.Title,
                    Message = s.Message,
                    SourceId = s.Id.ToString(),
                    CreatedTime = s.CreatedAt,
                    User = users.FirstOrDefault(f => f.Email == s.AuthorEmail)!,
                    Project = project
                }).ToList();

                await Command.Db.AddRangeAsync(newCommits);
            }
            return await SaveChangesAsync() > 0;
        }
        return default;
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
