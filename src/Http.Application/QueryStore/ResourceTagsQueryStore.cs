namespace Http.Application.QueryStore;
public class ResourceTagsQueryStore : QuerySet<ResourceTags>
{
    public ResourceTagsQueryStore(QueryDbContext context, ILogger<ResourceTagsQueryStore> logger) : base(context, logger)
    {
    }
}


