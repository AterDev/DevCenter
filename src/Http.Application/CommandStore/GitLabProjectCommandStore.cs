namespace Http.Application.CommandStore;
public class GitLabProjectCommandStore : CommandSet<GitLabProject>
{
    public GitLabProjectCommandStore(CommandDbContext context, ILogger<GitLabProjectCommandStore> logger) : base(context, logger)
    {
    }

}
