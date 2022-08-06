using Share.Models.ResourceGroupDtos;

namespace Http.Application.Manager;

public class ResourceGroupManager : DomainManagerBase<ResourceGroup, ResourceGroupUpdateDto, ResourceGroupFilterDto>, IResourceGroupManager
{
    public ResourceGroupManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<ResourceGroup> UpdateAsync(ResourceGroup entity, ResourceGroupUpdateDto dto)
    {
        if (dto.EnvironmentId != null)
        {
            var environment = await Stores.EnvironmentCommand.FindAsync(e => e.Id == dto.EnvironmentId);
            if (environment != null)
            {
                entity.Environment = environment;
            }
        }
        return await base.UpdateAsync(entity, dto);
    }


    public async Task<ResourceGroup?> FindAsync(Guid id)
    {
        return await Query.Db
            .Include(g => g.Environment)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public override async Task<PageList<TItem>> FilterAsync<TItem>(ResourceGroupFilterDto filter)
    {
        var query = GetQueryable();
        // 根据当前用户筛选
        if (filter.UserId != null)
        {
            // 查询用户对应的角色
            var roles = await Stores.QueryContext.Users.Where(u => u.Id == filter.UserId)
                .SelectMany(u => u.Roles!).ToListAsync();
            if (roles.Any())
            {
                // 查询角色包含的资源组
                var roleIds = roles.Select(r => r.Id).ToList();
                var groups = await Stores.QueryContext.Roles.Where(r => roleIds.Contains(r.Id))
                    .SelectMany(r => r.ResourceGroups!)
                    .ToListAsync();

                if (groups.Any())
                {
                    var groupIds = groups.Select(g => g.Id).ToList();
                    query = query.Where(q => groupIds.Contains(q.Id));
                }
            }
        }

        if (filter.Navigation != null)
        {
            query = query.Where(q => q.Navigation == filter.Navigation);
        }
        if (filter.EnvironmentId != null)
        {
            query = query.Where(q => q.Environment.Id == filter.EnvironmentId);
        }
        query = query.OrderBy(q => q.Sort)
            .OrderBy(q => q.Environment.Name)
            .Include(q => q.Environment)
            .Include(q => q.Resources)!
                .ThenInclude(r => r.Attributes)
            .Include(q => q.Resources)!
                .ThenInclude(r => r.Tags)
            .Include(q => q.Resources)!
                .ThenInclude(r => r.ResourceType);
        return await base.FilterAsync<TItem>(filter);
    }

    /// <summary>
    /// 获取角色的资源组
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public async Task<List<ResourceGroupRoleDto>> GetRoleResourceGroupsAsync(Guid? roleId)
    {
        var query = GetQueryable();
        if (roleId != null)
        {
            var role = await Stores.QueryContext.Roles.FindAsync(roleId);
            query = query.Where(d => d.Roles!.Contains(role!));
        }
        return await query.Select<ResourceGroup, ResourceGroupRoleDto>()
            .ToListAsync();
    }
}
