using Share.Models.ResourceAttributeDtos;
namespace Http.Application.DataStore;
public class ResourceAttributeDataStore : DataStoreBase<ContextBase, ResourceAttribute, ResourceAttributeUpdateDto, ResourceAttributeFilterDto, ResourceAttributeItemDto>
{
    public ResourceAttributeDataStore(ContextBase context, IUserContext userContext, ILogger<ResourceAttributeDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<ResourceAttributeItemDto>> FindAsync(ResourceAttributeFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageResult<ResourceAttributeItemDto>> FindWithPageAsync(ResourceAttributeFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<ResourceAttribute> AddAsync(ResourceAttribute data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<ResourceAttribute?> UpdateAsync(Guid id, ResourceAttributeUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
