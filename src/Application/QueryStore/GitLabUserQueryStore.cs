using Application.Implement;

namespace Application.QueryStore;
public class GitLabUserQueryStore : QuerySet<GitLabUser>
{
    public GitLabUserQueryStore(QueryDbContext context, ILogger<GitLabUserQueryStore> logger) : base(context, logger)
    {
    }
}


