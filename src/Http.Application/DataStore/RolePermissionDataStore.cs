using Share.Models.RolePermissionDtos;
namespace Http.Application.DataStore;
public class RolePermissionDataStore : DataStoreBase<ContextBase, RolePermission, RolePermissionUpdateDto, RolePermissionFilterDto, RolePermissionItemDto>
{
    public RolePermissionDataStore(ContextBase context, IUserContext userContext, ILogger<RolePermissionDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<RolePermissionItemDto>> FindAsync(RolePermissionFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<RolePermissionItemDto>> FindWithPageAsync(RolePermissionFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<RolePermission> AddAsync(RolePermission data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<RolePermission?> UpdateAsync(Guid id, RolePermissionUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
