using Application.Implement;

namespace Application.QueryStore;
public class ResourceQueryStore : QuerySet<Resource>
{
    public ResourceQueryStore(QueryDbContext context, ILogger<ResourceQueryStore> logger) : base(context, logger)
    {
    }
}


