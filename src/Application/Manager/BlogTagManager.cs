using Application.IManager;
using Application.Implement;
using Share.Models.BlogTagDtos;

namespace Application.Manager;

public class BlogTagManager : DomainManagerBase<BlogTag, BlogTagUpdateDto, BlogTagFilterDto, BlogTagItemDto>, IBlogTagManager
{
    public BlogTagManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<BlogTag> UpdateAsync(BlogTag entity, BlogTagUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<BlogTagItemDto>> FilterAsync(BlogTagFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        // if ... Queryable = ...
        return await Query.FilterAsync<BlogTagItemDto>(Queryable);
    }

}
