namespace Http.Application.QueryStore;
public class BlogTagQueryStore : QuerySet<BlogTag>
{
    public BlogTagQueryStore(QueryDbContext context, ILogger<BlogTagQueryStore> logger) : base(context, logger)
    {
    }
}


