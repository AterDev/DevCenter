using Application.IManager;
using Application.Implement;
using Share.Models.ResourceDtos;

namespace Application.Manager;

public class ResourceManager : DomainManagerBase<Resource, ResourceUpdateDto, ResourceFilterDto, ResourceItemDto>, IResourceManager
{
    private readonly IResourceTypeDefinitionManager typeDefinitionManager;
    private readonly IResourceTagsManager tagsManager;
    private readonly IResourceGroupManager resourceGroupManager;



    public ResourceManager(DataStoreContext storeContext,
                           IResourceTypeDefinitionManager typeDefinitionManager,
                           IResourceTagsManager tagsManager,
                           IResourceGroupManager resourceGroupManager) : base(storeContext)
    {
        this.typeDefinitionManager = typeDefinitionManager;
        this.tagsManager = tagsManager;
        this.resourceGroupManager = resourceGroupManager;
    }

    /// <summary>
    /// 获取资源内容
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Resource?> GetFullResource(Guid id)
    {
        return Query.Db.Include(d => d.Attributes)
            .Include(d => d.ResourceType)
            .Include(d => d.Tags)
            .Include(d => d.Group)
            .Where(d => d.Id == id)
            .FirstOrDefaultAsync();
    }

    public override async Task<Resource?> GetCurrent(Guid id, params string[]? navigations)
    {
        return await Command.Db.Include(d => d.Attributes)
            .Include(d => d.ResourceType)
            .Include(d => d.Tags)
            .Include(d => d.Group)
            .Where(d => d.Id == id)
            .FirstOrDefaultAsync();
    }

    public override async Task<Resource> UpdateAsync(Resource entity, ResourceUpdateDto dto)
    {
        Resource resource = entity;
        resource!.Attributes = null;
        resource!.Tags = null;
        if (dto.ResourceTypeId != null)
        {
            ResourceTypeDefinition? resourceType = await typeDefinitionManager.GetCurrentAsync(dto.ResourceTypeId.Value);
            resource.ResourceType = resourceType!;
        }
        if (dto.GroupId != null)
        {
            ResourceGroup? group = await resourceGroupManager.GetCurrentAsync(dto.GroupId.Value);
            resource.Group = group!;
        }
        if (dto.TagIds != null)
        {
            List<ResourceTags> tags = await tagsManager.Command.ListAsync(t => dto.TagIds.Contains(t.Id));
            resource.Tags = tags;
        }
        if (dto.AttributeAddItem != null)
        {
            List<ResourceAttribute> attributes = new();
            dto.AttributeAddItem.ForEach(a =>
            {
                ResourceAttribute attribute = new();
                attribute = attribute.Merge(a);
                attributes.Add(attribute);
            });
            resource.Attributes = attributes;
        }
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<ResourceItemDto>> FilterAsync(ResourceFilterDto filter)
    {
        IQueryable<Resource> query = Queryable;
        if (filter.GroupId != null)
        {
            query = query.Where(q => q.Group.Id == filter.GroupId);
        }
        return await Query.FilterAsync<ResourceItemDto>(query);
    }

    /// <summary>
    /// 获取当前用户可查询的所有资源
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public async Task<List<Resource>> GetAllResourcesAsync(Guid UserId)
    {
        List<Role> roles = await Stores.UserQuery.Db.Where(u => u.Id == UserId)
            .SelectMany(s => s.Roles!)
            .ToListAsync();

        List<Guid> groupIds = await Stores.RoleQuery.Db.Where(r => roles.Contains(r))
            .SelectMany(r => r.ResourceGroups!)
            .Select(s => s.Id)
            .ToListAsync();

        List<Resource> resources = await Query.Db.Where(r => groupIds.Contains(r.Group.Id))
            .Include(r => r.Attributes)
            .ToListAsync();
        return resources;
    }

    public override async Task<Resource?> DeleteAsync(Resource entity, bool softDelete = false)
    {
        if (entity!.Attributes != null)
        {
            Stores.CommandContext.RemoveRange(entity.Attributes);
        }
        entity.Tags = null;
        return await base.DeleteAsync(entity, softDelete);
    }

    public async Task<ResourceSelectDataDto> GetRelationSelectDataAsync()
    {
        QueryDbContext _context = Query.Context;
        List<Selection> types = await _context.ResourceTypeDefinitions
           .Select(s => new Selection
           {
               Id = s.Id,
               Name = s.Name
           }).ToListAsync();

        List<Selection> tags = await _context.ResourceTags
            .Select(s => new Selection
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();

        List<Selection> group = await _context.ResourceGroups
            .Select(s => new Selection
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();

        return new ResourceSelectDataDto
        {
            TypeDefines = types,
            Group = group,
            Tags = tags
        };
    }
}
