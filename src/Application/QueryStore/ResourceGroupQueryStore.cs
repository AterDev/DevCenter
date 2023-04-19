using Application.Implement;

namespace Application.QueryStore;
public class ResourceGroupQueryStore : QuerySet<ResourceGroup>
{
    public ResourceGroupQueryStore(QueryDbContext context, ILogger<ResourceGroupQueryStore> logger) : base(context, logger)
    {
    }
}


