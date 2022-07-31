using Core.Entities.Resource;
using Http.Application.Implement;
using Share.Models.ResourceTypeDefinitionDtos;
namespace Http.Application.DataStore;
public class ResourceTypeDefinitionDataStore : DataStoreBase<ContextBase, ResourceTypeDefinition, ResourceTypeDefinitionUpdateDto, ResourceTypeDefinitionFilterDto, ResourceTypeDefinitionItemDto>
{
    public ResourceTypeDefinitionDataStore(ContextBase context, IUserContext userContext, ILogger<ResourceTypeDefinitionDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<ResourceTypeDefinitionItemDto>> FindAsync(ResourceTypeDefinitionFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<ResourceTypeDefinitionItemDto>> FindWithPageAsync(ResourceTypeDefinitionFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<ResourceTypeDefinition> AddAsync(ResourceTypeDefinition data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<ResourceTypeDefinition?> UpdateAsync(Guid id, ResourceTypeDefinitionUpdateDto dto)
    {
        var typeDefine = await _db.FindAsync(id);
        typeDefine.Merge(dto);
        typeDefine!.AttributeDefines = null;
        if (dto.AttributeDefineIds != null)
        {
            var attributeDefines = await _context.ResourceAttributeDefines.Where(a => dto.AttributeDefineIds.Contains(a.Id)).ToListAsync();
            typeDefine.AttributeDefines = attributeDefines;
        }
        await _context.SaveChangesAsync();
        return typeDefine;
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }

    public override async Task<ResourceTypeDefinition?> FindAsync(Guid id, bool noTracking = false)
    {
        return await _db.Include(d => d.AttributeDefines)
            .SingleOrDefaultAsync(d => d.Id == id);
    }
}
