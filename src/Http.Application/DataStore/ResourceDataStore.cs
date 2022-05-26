using Share.Models.ResourceDtos;
namespace Http.Application.DataStore;
public class ResourceDataStore : DataStoreBase<ContextBase, Resource, ResourceUpdateDto, ResourceFilterDto, ResourceItemDto>
{
    public ResourceDataStore(ContextBase context, IUserContext userContext, ILogger<ResourceDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<ResourceItemDto>> FindAsync(ResourceFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageResult<ResourceItemDto>> FindWithPageAsync(ResourceFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<Resource> AddAsync(Resource data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<Resource?> UpdateAsync(Guid id, ResourceUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
