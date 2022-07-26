using Share.Models.ResourceAttributeDefineDtos;

namespace Http.Application.Manager;

public class ResourceAttributeDefineManager : DomainManagerBase<ResourceAttributeDefine, ResourceAttributeDefineUpdateDto, ResourceAttributeDefineFilterDto>, IResourceAttributeDefineManager
{
    public ResourceAttributeDefineManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<ResourceAttributeDefine> UpdateAsync(ResourceAttributeDefine entity, ResourceAttributeDefineUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<TItem>> FilterAsync<TItem>(ResourceAttributeDefineFilterDto filter)
    {
        var query = GetQueryable();
        if (filter.IsEnable != null)
        {
            query = query.Where(e => e.IsEnable == filter.IsEnable);
        }

        if (filter.TypeId != null)
        {
            var ids = await Query.Context.ResourceTypeDefinitions
                .Where(r => r.Id == filter.TypeId)
                .SelectMany(s => s.AttributeDefines!)
                .Select(d => d.Id)
                .ToListAsync();
            if (ids != null)
                query = query.Where(q => ids.Contains(q.Id));
        }
        return await Query.FilterAsync<TItem>(query, filter.OrderBy, filter.PageIndex ?? 1, filter.PageSize ?? 12);
    }

}
