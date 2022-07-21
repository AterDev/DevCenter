namespace Http.Application.DataStore;
public class UserQueryDataStore : QuerySet<User>
{
    public UserQueryDataStore(QueryDbContext context, ILogger<UserQueryDataStore> logger) : base(context, logger)
    {
    }

    public override Task<TDto?> FindAsync<TDto>(Guid id) where TDto : class
    {
        _query = _query.Include(q => q.Roles);
        return base.FindAsync<TDto>(id);
    }

}


