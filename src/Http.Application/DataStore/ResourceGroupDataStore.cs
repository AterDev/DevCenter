using Share.Models.ResourceGroupDtos;
namespace Http.Application.DataStore;
public class ResourceGroupDataStore : DataStoreBase<ContextBase, ResourceGroup, ResourceGroupUpdateDto, ResourceGroupFilterDto, ResourceGroupItemDto>
{
    public ResourceGroupDataStore(ContextBase context, IUserContext userContext, ILogger<ResourceGroupDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<ResourceGroupItemDto>> FindAsync(ResourceGroupFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageResult<ResourceGroupItemDto>> FindWithPageAsync(ResourceGroupFilterDto filter)
    {
        // 根据当前用户筛选
        if (filter.UserId != null)
        {
            // 查询用户对应的角色
            var roles = await _context.Users.Where(u => u.Id == filter.UserId)
                .SelectMany(u => u.Roles!).ToListAsync();
            if (roles.Any())
            {
                // 查询角色包含的资源组
                var roleIds = roles.Select(r => r.Id).ToList();
                var groups = await _context.Roles.Where(r => roleIds.Contains(r.Id))
                    .SelectMany(r => r.ResourceGroups!)
                    .ToListAsync();

                if (groups.Any())
                {
                    var groupIds = groups.Select(g => g.Id).ToList();
                    _query = _query.Where(q => groupIds.Contains(q.Id));
                }
            }
        }

        if (filter.Navigation != null)
        {
            _query = _query.Where(q => q.Navigation == filter.Navigation);
        }
        if (filter.EnvironmentId != null)
        {
            _query = _query.Where(q => q.Environment.Id == filter.EnvironmentId);
        }
        var count = _query.Count();
        if (filter.PageIndex < 1)
        {
            filter.PageIndex = 1;
        }

        if (filter.PageSize < 0)
        {
            filter.PageSize = 0;
        }

        var data = await _query.AsNoTracking()
            .Include(q => q.Environment)
            .Include(q => q.Resources)!
                .ThenInclude(r => r.Attributes)
            .Include(q => q.Resources)!
                .ThenInclude(r => r.Tags)
            .Include(q => q.Resources)!
                .ThenInclude(r => r.ResourceType)

            .Skip((filter.PageIndex - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(s => new ResourceGroupItemDto()
            {
                Id = s.Id,
                Name = s.Name,
                Resource = s.Resources,
                Environment = s.Environment,
                Descriptioin = s.Descriptioin,
                Navigation = s.Navigation,
            })
            .ToListAsync();
        return new PageResult<ResourceGroupItemDto>
        {
            Count = count,
            Data = data,
            PageIndex = filter.PageIndex
        };
    }

    public override async Task<ResourceGroup?> FindAsync(Guid id, bool noTracking = false)
    {
        return await _db.Include(g => g.Environment)
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    /// <summary>
    /// 获取角色的资源组
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public async Task<List<ResourceGroupRoleDto>> GetRoleResourceGroupsAsync(Guid? roleId)
    {
        var query = _db.AsQueryable();
        if (roleId != null)
        {
            var role = await _context.Roles.FindAsync(roleId);
            query = query.Where(d => d.Roles!.Contains(role!));
        }
        return await query.Select<ResourceGroup, ResourceGroupRoleDto>()
            .ToListAsync();
    }
    public override async Task<ResourceGroup> AddAsync(ResourceGroup data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<ResourceGroup?> UpdateAsync(Guid id, ResourceGroupUpdateDto dto)
    {
        var data = await _db.FindAsync(id);
        if (data == null) { return null; }
        // merge data and save 
        data.Merge(dto);
        if (dto.EnvironmentId != null)
        {
            var environment = await _context.Environments.FindAsync(dto.EnvironmentId);
            if (environment != null)
                data.Environment = environment;
        }
        data.UpdatedTime = DateTimeOffset.UtcNow;
        await _context.SaveChangesAsync();
        return data;
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
