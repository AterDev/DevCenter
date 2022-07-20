namespace Http.Application.DataStore;
public class UserQueryDataStore : DataStoreQueryBase<QueryDbContext, User>
{
    public UserQueryDataStore(QueryDbContext context, ILogger logger) : base(context, logger)
    {
    }
}


