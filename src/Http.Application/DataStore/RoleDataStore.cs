using Share.Models.RoleDtos;
namespace Http.Application.DataStore;
public class RoleDataStore : DataStoreBase<ContextBase, Role, RoleUpdateDto, RoleFilterDto, RoleItemDto>
{
    public RoleDataStore(ContextBase context, IUserContext userContext, ILogger<RoleDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<RoleItemDto>> FindAsync(RoleFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageResult<RoleItemDto>> FindWithPageAsync(RoleFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<Role> AddAsync(Role data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<Role?> UpdateAsync(Guid id, RoleUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }

    public async Task<bool> SetResourceGorupsAsync(RoleResourceDto dto)
    {
        var role = await _db.Include(r => r.ResourceGroups)
            .FirstOrDefaultAsync(r => r.Id == dto.RoleId);
        role!.ResourceGroups = null;
        var groups = await _context.ResourceGroups.Where(g => dto.GroupIds.Contains(g.Id))
            .ToListAsync();

        role.ResourceGroups = groups;
        return await _context.SaveChangesAsync() > 0;
    }
}
