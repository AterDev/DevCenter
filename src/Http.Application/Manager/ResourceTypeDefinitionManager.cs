using Share.Models.ResourceTypeDefinitionDtos;

namespace Http.Application.Manager;

public class ResourceTypeDefinitionManager : DomainManagerBase<ResourceTypeDefinition, ResourceTypeDefinitionUpdateDto, ResourceTypeDefinitionFilterDto, ResourceTypeDefinitionItemDto>, IResourceTypeDefinitionManager
{
    public ResourceTypeDefinitionManager(DataStoreContext storeContext) : base(storeContext)
    {
    }

    public override async Task<ResourceTypeDefinition> UpdateAsync(ResourceTypeDefinition entity, ResourceTypeDefinitionUpdateDto dto)
    {
        // 更新关联的内容
        entity!.AttributeDefines = null;
        if (dto.AttributeDefineIds != null)
        {
            // 通过父类的 Stores 查询其他实体的内容
            var attributeDefines = await Stores.ResourceAttributeDefineCommand.Db.Where(a => dto.AttributeDefineIds.Contains(a.Id)).ToListAsync();
            entity.AttributeDefines = attributeDefines;
        }
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<ResourceTypeDefinitionItemDto>> FilterAsync(ResourceTypeDefinitionFilterDto filter)
    {
        // TODO:根据实际业务构建筛选条件
        return await base.FilterAsync(filter);
    }

    public override async Task<ResourceTypeDefinition?> FindAsync(Guid id)
    {
        return await Query.Db.Include(d => d.AttributeDefines)
            .SingleOrDefaultAsync(d => d.Id == id);
    }

}
