using Share.Models.CodeLibraryDtos;

namespace Http.Application.Manager;

public class CodeLibraryManager : DomainManagerBase<CodeLibrary, CodeLibraryUpdateDto, CodeLibraryFilterDto, CodeLibraryItemDto>, ICodeLibraryManager
{
    public CodeLibraryManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<CodeLibrary> UpdateAsync(CodeLibrary entity, CodeLibraryUpdateDto dto)
    {
        // TODO:根据实际业务更新
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<CodeLibraryItemDto>> FilterAsync(CodeLibraryFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        // if ... Queryable = ...
        return await Query.FilterAsync<CodeLibraryItemDto>(Queryable);
    }

}
