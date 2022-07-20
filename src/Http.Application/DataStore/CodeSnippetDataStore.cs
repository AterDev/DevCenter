using Http.Application.Implement;
using Share.Models.CodeSnippetDtos;
namespace Http.Application.DataStore;
public class CodeSnippetDataStore : DataStoreBase<ContextBase, CodeSnippet, CodeSnippetUpdateDto, CodeSnippetFilterDto, CodeSnippetItemDto>
{
    public CodeSnippetDataStore(ContextBase context, IUserContext userContext, ILogger<CodeSnippetDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<CodeSnippetItemDto>> FindAsync(CodeSnippetFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<CodeSnippetItemDto>> FindWithPageAsync(CodeSnippetFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<CodeSnippet> AddAsync(CodeSnippet data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<CodeSnippet?> UpdateAsync(Guid id, CodeSnippetUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
