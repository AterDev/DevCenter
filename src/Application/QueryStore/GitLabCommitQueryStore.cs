using Application.Implement;

namespace Application.QueryStore;
public class GitLabCommitQueryStore : QuerySet<GitLabCommit>
{
    public GitLabCommitQueryStore(QueryDbContext context, ILogger<GitLabCommitQueryStore> logger) : base(context, logger)
    {
    }
}


