namespace Http.Application.DataStore;
public class UserQueryDataStore : QuerySet<User>
{
    public UserQueryDataStore(QueryDbContext context, ILogger<UserQueryDataStore> logger) : base(context, logger)
    {
    }
}


