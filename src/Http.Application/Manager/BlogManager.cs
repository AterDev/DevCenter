using Share.Models.BlogDtos;

namespace Http.Application.Manager;

public class BlogManager : DomainManagerBase<Blog, BlogUpdateDto, BlogFilterDto>, IBlogManager
{
    public BlogManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<Blog> UpdateAsync(Blog entity, BlogUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<TItem>> FilterAsync<TItem>(BlogFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        return await base.FilterAsync<TItem>(filter);
    }

}
