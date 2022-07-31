namespace Http.Application.QueryStore;
public class CommentQueryStore : QuerySet<Comment>
{
    public CommentQueryStore(QueryDbContext context, ILogger<CommentQueryStore> logger) : base(context, logger)
    {
    }
}


