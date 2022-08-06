using Share.Models.ResourceDtos;

namespace Http.Application.Manager;

public class ResourceManager : DomainManagerBase<Resource, ResourceUpdateDto, ResourceFilterDto>, IResourceManager
{
    public ResourceManager(DataStoreContext storeContext) : base(storeContext)
    {
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
        var resource = entity;
        resource!.Attributes = null;
        resource!.Tags = null;
        //if (dto.ResourceTypeId != null)
        //{
        //    var resourceType = await _context.ResourceTypeDefinitions.FindAsync(dto.ResourceTypeId);
        //    resource.ResourceType = resourceType!;
        //}
        //if (dto.GroupId != null)
        //{
        //    var group = await _context.ResourceGroups.FindAsync(dto.GroupId);
        //    resource.Group = group!;
        //}
        //if (dto.TagIds != null)
        //{
        //    var tags = await _context.ResourceTags.Where(t => dto.TagIds.Contains(t.Id)).ToListAsync();
        //    resource.Tags = tags;
        //}
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
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<TItem>> FilterAsync<TItem>(ResourceFilterDto filter)
    {
        var query = GetQueryable();
        query = query.Where(q => q.Group.Id == filter.GroupId);
        return await Query.FilterAsync<TItem>(query);
    }

}
