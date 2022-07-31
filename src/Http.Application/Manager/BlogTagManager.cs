using Http.Application.IManager;
using Share.Models.BlogTagDtos;

namespace Http.Application.Manager;

public class BlogTagManager : DomainManagerBase<BlogTag, BlogTagUpdateDto, BlogTagFilterDto>, IBlogTagManager
{
    public BlogTagManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<BlogTag> UpdateAsync(BlogTag entity, BlogTagUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<TItem>> FilterAsync<TItem>(BlogTagFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        return await  base.FilterAsync<TItem>(filter);
    }

}
