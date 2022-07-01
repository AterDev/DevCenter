using Share.Models.ResourceAttributeDefineDtos;
namespace Http.Application.DataStore;
public class ResourceAttributeDefineDataStore : DataStoreBase<ContextBase, ResourceAttributeDefine, ResourceAttributeDefineUpdateDto, ResourceAttributeDefineFilterDto, ResourceAttributeDefineItemDto>
{
    public ResourceAttributeDefineDataStore(ContextBase context, IUserContext userContext, ILogger<ResourceAttributeDefineDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<ResourceAttributeDefineItemDto>> FindAsync(ResourceAttributeDefineFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageResult<ResourceAttributeDefineItemDto>> FindWithPageAsync(ResourceAttributeDefineFilterDto filter)
    {
        _query = _query.OrderBy(q => q.Sort);
        if (filter.IsEnable != null)
        {
            _query = _query.Where(q => q.IsEnable == filter.IsEnable);
        }
        if (filter.TypeId != null)
        {
            var ids = await _context.ResourceTypeDefinitions
                .Where(r => r.Id == filter.TypeId && r.AttributeDefines != null)
                .SelectMany(s => s.AttributeDefines)
                .Select(d => d.Id)
                .ToListAsync();

            if (ids != null)
                _query = _query.Where(q => ids.Contains(q.Id));
        }
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<ResourceAttributeDefine> AddAsync(ResourceAttributeDefine data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<ResourceAttributeDefine?> UpdateAsync(Guid id, ResourceAttributeDefineUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }

}
