using Http.Application.Implement;
using Share.Models.DocFolderDtos;
namespace Http.Application.DataStore;
public class DocFolderDataStore : DataStoreBase<ContextBase, DocFolder, DocFolderUpdateDto, DocFolderFilterDto, DocFolderItemDto>
{
    public DocFolderDataStore(ContextBase context, IUserContext userContext, ILogger<DocFolderDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<DocFolderItemDto>> FindAsync(DocFolderFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<DocFolderItemDto>> FindWithPageAsync(DocFolderFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<DocFolder> AddAsync(DocFolder data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<DocFolder?> UpdateAsync(Guid id, DocFolderUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
