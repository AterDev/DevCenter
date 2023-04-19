using Application.Implement;

namespace Application.CommandStore;
public class GitLabCommitCommandStore : CommandSet<GitLabEvent>
{
    public GitLabCommitCommandStore(CommandDbContext context, ILogger<GitLabCommitCommandStore> logger) : base(context, logger)
    {
    }

}
