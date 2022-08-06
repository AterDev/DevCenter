using Share.Models.CommentDtos;

namespace Http.Application.Manager;

public class CommentManager : DomainManagerBase<Comment, CommentUpdateDto, CommentFilterDto, CommentItemDto>, ICommentManager
{
    public CommentManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<Comment> UpdateAsync(Comment entity, CommentUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<CommentItemDto>> FilterAsync(CommentFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        // if ... Queryable = ...
        return await Query.FilterAsync<CommentItemDto>(Queryable);
    }

}
