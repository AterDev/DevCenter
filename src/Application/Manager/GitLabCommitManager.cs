using Share.Models.GitLabCommitDtos;
using Application.Implement;
using Application.Interface;
using Application.IManager;
using NGitLab;
using Share.Options;
using Microsoft.Extensions.Options;
using System;

namespace Application.Manager;

public class GitLabCommitManager : DomainManagerBase<GitLabEvent, GitLabCommitUpdateDto, GitLabCommitFilterDto, GitLabCommitItemDto>, IGitLabCommitManager
{
    private readonly IUserContext _userContext;
    private readonly GitLabOption _gitlabOption;
    public GitLabClient GitLabClient { get; set; }


    public GitLabCommitManager(
        DataStoreContext storeContext,
        IOptions<GitLabOption> gitlabOption,
        IUserContext userContext) : base(storeContext)
    {
        _userContext = userContext;
        _gitlabOption = gitlabOption.Value;
        GitLabClient = new GitLabClient(_gitlabOption.URL, _gitlabOption.PAT);
    }

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<GitLabEvent> CreateNewEntityAsync(GitLabCommitAddDto dto)
    {
        var entity = dto.MapTo<GitLabCommitAddDto, GitLabEvent>();
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
        var project = await Stores.GitLabProjectCommand.Db.SingleOrDefaultAsync(s => s.SourceId == projectId);
        if (project != null)
        {

            var exist = Query.Db.Any(q => q.Project.Id == project.Id);
            // get all users and project from database
            var users = await Stores.GitLabUserCommand.Db.ToListAsync();


            users.ForEach(user =>
            {
                var events = GitLabClient.GetUserEvents(user.SourceId)
                    .Get(new NGitLab.Models.EventQuery
                    {
                        PerPage = 1000
                    }).ToList();

                Console.WriteLine(  );
            });

        }
        return default;
    }

    public override async Task<GitLabEvent> UpdateAsync(GitLabEvent entity, GitLabCommitUpdateDto dto)
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
    public async Task<GitLabEvent?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
