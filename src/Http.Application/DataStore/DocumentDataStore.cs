using Share.Models.DocumentDtos;
namespace Http.Application.DataStore;
public class DocumentDataStore : DataStoreBase<ContextBase, Document, DocumentUpdateDto, DocumentFilterDto, DocumentItemDto>
{
    public DocumentDataStore(ContextBase context, IUserContext userContext, ILogger<DocumentDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<DocumentItemDto>> FindAsync(DocumentFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<DocumentItemDto>> FindWithPageAsync(DocumentFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<Document> AddAsync(Document data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<Document?> UpdateAsync(Guid id, DocumentUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
