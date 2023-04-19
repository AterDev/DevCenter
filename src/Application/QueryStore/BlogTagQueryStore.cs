using Application.Implement;

namespace Application.QueryStore;
public class BlogTagQueryStore : QuerySet<BlogTag>
{
    public BlogTagQueryStore(QueryDbContext context, ILogger<BlogTagQueryStore> logger) : base(context, logger)
    {
    }
}


