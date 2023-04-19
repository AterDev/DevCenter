using Application.Implement;

namespace Application.CommandStore;
public class BlogCatalogCommandStore : CommandSet<BlogCatalog>
{
    public BlogCatalogCommandStore(CommandDbContext context, ILogger<BlogCatalogCommandStore> logger) : base(context, logger)
    {
    }

}
