namespace Http.Application.QueryStore;
public class EnvironmentQueryStore : QuerySet<Environment>
{
    public EnvironmentQueryStore(QueryDbContext context, ILogger<EnvironmentQueryStore> logger) : base(context, logger)
    {
    }
}


