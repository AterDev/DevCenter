using Http.Application.Implement;

namespace Http.Application.DataStore;
public class UserCommandDataStore : DataStoreCommandBase<CommandDbContext, User>
{
    public UserCommandDataStore(CommandDbContext context, ILogger logger) : base(context, logger)
    {
    }
}
