using Share.Models.CodeFolderDtos;
namespace Http.Application.DataStore;
public class CodeFolderDataStore : DataStoreBase<ContextBase, CodeFolder, CodeFolderUpdateDto, CodeFolderFilterDto, CodeFolderItemDto>
{
    public CodeFolderDataStore(ContextBase context, IUserContext userContext, ILogger<CodeFolderDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<CodeFolderItemDto>> FindAsync(CodeFolderFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<CodeFolderItemDto>> FindWithPageAsync(CodeFolderFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<CodeFolder> AddAsync(CodeFolder data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<CodeFolder?> UpdateAsync(Guid id, CodeFolderUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
