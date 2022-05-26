using Share.Models.ResourceTypeDefinitionDtos;
namespace Http.Application.DataStore;
public class ResourceTypeDefinitionDataStore : DataStoreBase<ContextBase, ResourceTypeDefinition, ResourceTypeDefinitionUpdateDto, ResourceTypeDefinitionFilterDto, ResourceTypeDefinitionItemDto>
{
    public ResourceTypeDefinitionDataStore(ContextBase context, IUserContext userContext, ILogger<ResourceTypeDefinitionDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<ResourceTypeDefinitionItemDto>> FindAsync(ResourceTypeDefinitionFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageResult<ResourceTypeDefinitionItemDto>> FindWithPageAsync(ResourceTypeDefinitionFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<ResourceTypeDefinition> AddAsync(ResourceTypeDefinition data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<ResourceTypeDefinition?> UpdateAsync(Guid id, ResourceTypeDefinitionUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
