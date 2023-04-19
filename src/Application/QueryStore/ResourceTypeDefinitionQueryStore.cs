using Application.Implement;

namespace Application.QueryStore;
public class ResourceTypeDefinitionQueryStore : QuerySet<ResourceTypeDefinition>
{
    public ResourceTypeDefinitionQueryStore(QueryDbContext context, ILogger<ResourceTypeDefinitionQueryStore> logger) : base(context, logger)
    {
    }
}


