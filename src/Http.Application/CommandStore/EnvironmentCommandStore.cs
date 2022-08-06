namespace Http.Application.CommandStore;
public class EnvironmentCommandStore : CommandSet<Environment>
{
    public EnvironmentCommandStore(CommandDbContext context, ILogger<EnvironmentCommandStore> logger) : base(context, logger)
    {
    }

}
