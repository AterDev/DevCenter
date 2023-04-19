using Application.Implement;

namespace Application.CommandStore;
public class GitLabUserCommandStore : CommandSet<GitLabUser>
{
    public GitLabUserCommandStore(CommandDbContext context, ILogger<GitLabUserCommandStore> logger) : base(context, logger)
    {
    }

}
