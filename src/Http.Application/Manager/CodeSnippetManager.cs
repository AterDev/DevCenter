using Share.Models.CodeSnippetDtos;

namespace Http.Application.Manager;

public class CodeSnippetManager : DomainManagerBase<CodeSnippet, CodeSnippetUpdateDto, CodeSnippetFilterDto, CodeSnippetItemDto>, ICodeSnippetManager
{
    public CodeSnippetManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<CodeSnippet> UpdateAsync(CodeSnippet entity, CodeSnippetUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<CodeSnippetItemDto>> FilterAsync(CodeSnippetFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        // if ... Queryable = ...
        return await Query.FilterAsync<CodeSnippetItemDto>(Queryable);
    }

}
