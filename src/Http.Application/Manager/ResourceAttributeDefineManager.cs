using Http.Application.IManager;
using Share.Models.ResourceAttributeDefineDtos;

namespace Http.Application.Manager;

public class ResourceAttributeDefineManager : DomainManagerBase<ResourceAttributeDefine, ResourceAttributeDefineUpdateDto>, IResourceAttributeDefineManager
{
    public ResourceAttributeDefineManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<ResourceAttributeDefine> UpdateAsync(ResourceAttributeDefine entity, ResourceAttributeDefineUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override Task<PageList<TItem>> FilterAsync<TItem, TFilter>(TFilter filter)
    {
        // TODO:根据实际业务构建筛选条件
        Expression<Func<ResourceAttributeDefine, bool>> exp = e => true;
        return Query.FilterAsync<TItem>(exp, filter.OrderBy, filter.PageIndex ?? 1, filter.PageSize ?? 12);
    }

}
