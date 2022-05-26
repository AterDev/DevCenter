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
}
