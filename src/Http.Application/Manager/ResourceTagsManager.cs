using Http.Application.IManager;
using Share.Models.ResourceTagsDtos;

namespace Http.Application.Manager;

public class ResourceTagsManager : DomainManagerBase<ResourceTags, ResourceTagsUpdateDto, ResourceTagsFilterDto>, IResourceTagsManager
{
    public ResourceTagsManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<ResourceTags> UpdateAsync(ResourceTags entity, ResourceTagsUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<TItem>> FilterAsync<TItem>(ResourceTagsFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        return await  base.FilterAsync<TItem>(filter);
    }

}
