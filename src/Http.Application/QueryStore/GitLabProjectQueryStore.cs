namespace Http.Application.QueryStore;
public class GitLabProjectQueryStore : QuerySet<GitLabProject>
{
    public GitLabProjectQueryStore(QueryDbContext context, ILogger<GitLabProjectQueryStore> logger) : base(context, logger)
    {
    }
}


