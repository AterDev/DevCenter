using Http.Application.Implement;

namespace Http.Application.DataStore;
public class UserCommandDataStore : CommandSet<User>
{
    public UserCommandDataStore(CommandDbContext context, ILogger<UserCommandDataStore> logger) : base(context, logger)
    {
    }
}
