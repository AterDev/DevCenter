using Http.Application.Implement;
using Share.Models.PermissionDtos;
namespace Http.Application.DataStore;
public class PermissionDataStore : DataStoreBase<ContextBase, Permission, PermissionUpdateDto, PermissionFilterDto, PermissionItemDto>
{
    public PermissionDataStore(ContextBase context, IUserContext userContext, ILogger<PermissionDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<PermissionItemDto>> FindAsync(PermissionFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<PermissionItemDto>> FindWithPageAsync(PermissionFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<Permission> AddAsync(Permission data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<Permission?> UpdateAsync(Guid id, PermissionUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
