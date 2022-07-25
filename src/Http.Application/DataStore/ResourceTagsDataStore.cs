using Share.Models.ResourceTagsDtos;
namespace Http.Application.DataStore;
public class ResourceTagsDataStore : DataStoreBase<ContextBase, ResourceTags, ResourceTagsUpdateDto, ResourceTagsFilterDto, ResourceTagsItemDto>
{
    public ResourceTagsDataStore(ContextBase context, IUserContext userContext, ILogger<ResourceTagsDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<ResourceTagsItemDto>> FindAsync(ResourceTagsFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<ResourceTagsItemDto>> FindWithPageAsync(ResourceTagsFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<ResourceTags> AddAsync(ResourceTags data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<ResourceTags?> UpdateAsync(Guid id, ResourceTagsUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
