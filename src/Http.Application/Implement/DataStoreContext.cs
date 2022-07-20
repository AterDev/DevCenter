using Http.Application.DataStore;

namespace Http.Application.Implement;
public class DataStoreContext
{
    public UserQueryDataStore UserQuery { get; set; }
    public UserCommandDataStore UserCommand { get; set; }

    public DataStoreContext(
        UserQueryDataStore userQuery,
        UserCommandDataStore userCommand
    )
    {
        UserQuery = userQuery;
        UserCommand = userCommand;
    }
}
