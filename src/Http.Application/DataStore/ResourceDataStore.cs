using Share.Models.ResourceDtos;
namespace Http.Application.DataStore;
public class ResourceDataStore : DataStoreBase<ContextBase, Resource, ResourceUpdateDto, ResourceFilterDto, ResourceItemDto>
{
    public ResourceDataStore(ContextBase context, IUserContext userContext, ILogger<ResourceDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<ResourceItemDto>> FindAsync(ResourceFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }
    public override async Task<Resource?> FindAsync(Guid id, bool noTracking = false)
    {
        var _query = _db.Include(d => d.Attributes)
            .Include(d => d.ResourceType)
            .Include(d => d.Tags)
            .Include(d => d.Group).AsQueryable();
        return noTracking == true
            ? await _query.AsNoTracking().SingleOrDefaultAsync(d => d.Id == id)
            : await _query.SingleOrDefaultAsync(d => d.Id == id);

    }
    public override async Task<PageList<ResourceItemDto>> FindWithPageAsync(ResourceFilterDto filter)
    {
        if (filter.GroupId != null)
        {
            _query = _query.Where(q => q.Group.Id == filter.GroupId);
        }
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<Resource> AddAsync(Resource data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<Resource?> UpdateAsync(Guid id, ResourceUpdateDto dto)
    {
        var resource = await FindAsync(id);
        resource = resource.Merge(dto);
        resource!.Attributes = null;
        resource!.Tags = null;
        if (dto.ResourceTypeId != null)
        {
            var resourceType = await _context.ResourceTypeDefinitions.FindAsync(dto.ResourceTypeId);
            resource.ResourceType = resourceType!;
        }
        if (dto.GroupId != null)
        {
            var group = await _context.ResourceGroups.FindAsync(dto.GroupId);
            resource.Group = group!;
        }
        if (dto.TagIds != null)
        {
            var tags = await _context.ResourceTags.Where(t => dto.TagIds.Contains(t.Id)).ToListAsync();
            resource.Tags = tags;
        }
        if (dto.AttributeAddItem != null)
        {
            var attributes = new List<ResourceAttribute>();
            dto.AttributeAddItem.ForEach(a =>
            {
                var attribute = new ResourceAttribute();
                attribute = attribute.Merge(a);
                attributes.Add(attribute);
            });
            resource.Attributes = attributes;
        }
        await _context.SaveChangesAsync();
        return resource;
    }

    /// <summary>
    /// ????????????????????????????
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public async Task<List<Resource>> GetAllResourcesAsync(Guid UserId)
    {
        var roles = await _context.Users.Where(u => u.Id == UserId)
            .SelectMany(s => s.Roles!)
            .ToListAsync();

        var groupIds = await _context.Roles.Where(r => roles.Contains(r))
            .AsNoTracking()
            .SelectMany(r => r.ResourceGroups!)
            .Select(s => s.Id)
            .ToListAsync();

        var resources = await _context.Resources.Where(r => groupIds.Contains(r.Group.Id))
            .Include(r => r.Attributes)
            .ToListAsync();
        return resources;
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        var resource = await FindAsync(id);
        if (resource!.Attributes != null)
        {
            _context.RemoveRange(resource.Attributes);
        }

        _context.Remove(resource);
        return await _context.SaveChangesAsync() > 0;
    }
    /// <summary>
    /// ????????????
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ResourceGroup?> FindGroupAsync(Guid id)
    {
        return await _context.ResourceGroups.FindAsync(id);
    }
    /// <summary>
    /// ??????????????
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ResourceTypeDefinition?> FindTypeAsync(Guid id)
    {
        return await _context.ResourceTypeDefinitions.FindAsync(id);
    }
    /// <summary>
    /// ????????
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task<List<ResourceTags>?> FindTagsAsync(List<Guid> ids)
    {
        return await _context.ResourceTags.Where(t => ids.Contains(t.Id))
            .ToListAsync();
    }

    /// <summary>
    /// ????????????????????
    /// </summary>
    public async Task<ResourceSelectDataDto> GetRelationSelectDataAsync()
    {
        var types = await _context.ResourceTypeDefinitions
            .Select(s => new Selection
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();

        var tags = await _context.ResourceTags
            .Select(s => new Selection
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();

        var group = await _context.ResourceGroups
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
