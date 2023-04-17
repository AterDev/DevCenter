namespace Http.Application.CommandStore;
public class GitLabCommitCommandStore : CommandSet<GitLabCommit>
{
    public GitLabCommitCommandStore(CommandDbContext context, ILogger<GitLabCommitCommandStore> logger) : base(context, logger)
    {
    }

}
