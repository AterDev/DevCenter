using Application.Implement;

namespace Application.QueryStore;
public class BlogCatalogQueryStore : QuerySet<BlogCatalog>
{
    public BlogCatalogQueryStore(QueryDbContext context, ILogger<BlogCatalogQueryStore> logger) : base(context, logger)
    {
    }
}


