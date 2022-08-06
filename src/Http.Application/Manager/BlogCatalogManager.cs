using Http.Application.IManager;
using Share.Models.BlogCatalogDtos;

namespace Http.Application.Manager;

public class BlogCatalogManager : DomainManagerBase<BlogCatalog, BlogCatalogUpdateDto, BlogCatalogFilterDto, BlogCatalogItemDto>, IBlogCatalogManager
{
    public BlogCatalogManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<BlogCatalog> UpdateAsync(BlogCatalog entity, BlogCatalogUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<BlogCatalogItemDto>> FilterAsync(BlogCatalogFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        // if ... Queryable = ...
        return await Query.FilterAsync<BlogCatalogItemDto>(Queryable);
    }

}
