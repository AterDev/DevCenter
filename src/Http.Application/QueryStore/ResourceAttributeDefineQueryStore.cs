namespace Http.Application.QueryStore;
public class ResourceAttributeDefineQueryStore : QuerySet<ResourceAttributeDefine>
{
    public ResourceAttributeDefineQueryStore(QueryDbContext context, ILogger<ResourceAttributeDefineQueryStore> logger) : base(context, logger)
    {
    }
}


