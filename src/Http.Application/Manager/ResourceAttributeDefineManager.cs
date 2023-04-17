using Share.Models.ResourceAttributeDefineDtos;

namespace Http.Application.Manager;

public class ResourceAttributeDefineManager : DomainManagerBase<ResourceAttributeDefine, ResourceAttributeDefineUpdateDto, ResourceAttributeDefineFilterDto, ResourceAttributeDefineItemDto>, IResourceAttributeDefineManager
{
    public ResourceAttributeDefineManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<ResourceAttributeDefine> UpdateAsync(ResourceAttributeDefine entity, ResourceAttributeDefineUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<ResourceAttributeDefineItemDto>> FilterAsync(ResourceAttributeDefineFilterDto filter)
    {
        IQueryable<ResourceAttributeDefine> query = Queryable;
        if (filter.IsEnable != null)
        {
            query = query.Where(e => e.IsEnable == filter.IsEnable);
        }

        if (filter.TypeId != null)
        {
            List<Guid> ids = await Query.Context.ResourceTypeDefinitions
                .Where(r => r.Id == filter.TypeId)
                .SelectMany(s => s.AttributeDefines!)
                .Select(d => d.Id)
                .ToListAsync();
            if (ids != null)
            {
                query = query.Where(q => ids.Contains(q.Id));
            }
        }
        return await Query.FilterAsync<ResourceAttributeDefineItemDto>(query, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

}
