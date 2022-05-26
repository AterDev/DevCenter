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
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<ResourceGroup> AddAsync(ResourceGroup data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<ResourceGroup?> UpdateAsync(Guid id, ResourceGroupUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
