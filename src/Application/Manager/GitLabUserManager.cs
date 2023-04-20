using Share.Models.GitLabUserDtos;
using Application.Implement;
using Application.Interface;
using Application.IManager;
using NGitLab;
using Microsoft.Extensions.Options;
using Share.Options;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Application.Manager;

public class GitLabUserManager : DomainManagerBase<GitLabUser, GitLabUserUpdateDto, GitLabUserFilterDto, GitLabUserItemDto>, IGitLabUserManager
{
    private readonly IUserContext _userContext;
    private readonly GitLabOption _gitlabOption;
    private readonly IGitLabProjectManager _projectManager;

    public GitLabUserManager(
        DataStoreContext storeContext,
        IUserContext userContext,
        IOptions<GitLabOption> options,
        IGitLabProjectManager projectManager) : base(storeContext)
    {
        _userContext = userContext;
        _gitlabOption = options.Value;
        _projectManager = projectManager;
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
        var currentIds = Query.Db
            .Select(s => s.SourceId)
            .ToList();

        var newIds = sourceIds.Except(currentIds);
        var newUser = users.Where(u => newIds.Contains(u.SourceId)).ToList();
        await Command.Db.AddRangeAsync(newUser);
        return await SaveChangesAsync() > 0;
    }

    /// <summary>
    /// 用户事件
    /// </summary>
    /// <param name="projectId"></param>
    /// <returns></returns>
    public async Task<bool> SyncUserEventsAsync()
    {
        // get all users and project from database
        var projects = await _projectManager.Command.Db.ToListAsync();
        var users = await Command.Db.ToListAsync();
        var client = new GitLabClient(_gitlabOption.URL, _gitlabOption.PAT);

        foreach (var user in users)
        {
            var synced = Query.Context.GitLabEvents.Any(e => e.User.Id == user.Id);
            if (synced)
            {
                // get events
                var events = client.GetUserEvents(user.SourceId)
                    .Get(new NGitLab.Models.EventQuery
                    {
                        PerPage = 20,
                        After = DateTime.UtcNow.AddHours(-4),
                    })
                    .Where(e => e.Action.EnumValue is NGitLab.Models.EventAction.PushedTo
                        or NGitLab.Models.EventAction.PushedNew)
                    .Select(s => new GitLabEvent
                    {
                        BranchName = s.PushData.Ref,
                        CommitTitle = s.PushData.CommitTitle ?? s.Action.EnumValue.ToString() ?? "",
                        Project = projects.Single(p => p.SourceId == s.ProjectId),
                        User = user,
                        CreatedTime = s.CreatedAt,
                        CommitCount = s.PushData.CommitCount,
                        Day = s.CreatedAt.Day,
                        Year = s.CreatedAt.Year,
                        Month = s.CreatedAt.Month,
                        SourceId = s.Id
                    }).ToList();

                // find new events which not exist in database
                var eventIds = events.Select(e => e.SourceId).ToList();
                // latest 20 
                var currentIds = await Query.Context.GitLabEvents
                    .OrderByDescending(e => e.CreatedTime)
                    .Select(e => e.SourceId)
                    .Take(20)
                    .ToListAsync();

                var newEventIds = eventIds.Except(currentIds).ToList();
                var newEvents = events.Where(e => newEventIds.Contains(e.SourceId)).ToList();
                await Command.Context.GitLabEvents.AddRangeAsync(newEvents);
                await SaveChangesAsync();
            }
            else
            {
                // all events
                var events = client.GetUserEvents(user.SourceId)
                    .Get(new NGitLab.Models.EventQuery
                    {
                        PerPage = 9999,
                    })
                    .Where(e => e.Action.EnumValue is NGitLab.Models.EventAction.PushedTo
                        or NGitLab.Models.EventAction.PushedNew)
                    .Select(s => new GitLabEvent
                    {
                        BranchName = s.PushData.Ref,
                        CommitTitle = s.PushData.CommitTitle ?? s.Action.EnumValue.ToString() ?? "",
                        Project = projects.Single(p => p.SourceId == s.ProjectId),
                        User = user,
                        CreatedTime = s.CreatedAt,
                        CommitCount = s.PushData.CommitCount,
                        Day = s.CreatedAt.Day,
                        Year = s.CreatedAt.Year,
                        Month = s.CreatedAt.Month,
                        SourceId = s.Id
                    }).ToList();

                var currentIds = await Query.Context.GitLabEvents
                    .Select(s => s.SourceId)
                    .ToListAsync();
                var newEventIds = events.Select(e => e.SourceId).Except(currentIds).ToList();
                var newEvents = events.Where(e => newEventIds.Contains(e.SourceId)).ToList();

                await Command.Context.GitLabEvents.AddRangeAsync(newEvents);
                await SaveChangesAsync();
            }
        }
        return default;
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
