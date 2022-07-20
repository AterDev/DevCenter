using Http.Application.DataStore;

namespace Http.Application.Implement;
public class DataStoreContext
{
    public QuerySet<User> UserQuery { get; set; }
    public CommandSet<User> UserCommand { get; set; }

    /// <summary>
    /// 绑在对象
    /// </summary>
    private Dictionary<string, object> SetCache = new();
    IServiceProvider ServiceProvider { get; set; }

    public DataStoreContext(
        IServiceProvider serviceProvider,
        UserQueryDataStore userQuery,
        UserCommandDataStore userCommand
    )
    {
        ServiceProvider = serviceProvider;
        UserQuery = userQuery;
        UserCommand = userCommand;

        AddCache(UserQuery);
        AddCache(UserCommand);
    }


    public QuerySet<TEntity> QuerySet<TEntity>() where TEntity : EntityBase
    {
        var typename = typeof(TEntity).Name + "QueryDataStore";
        var set = GetSet(typename);
        if (set == null) throw new ArgumentNullException($"{typename} class object not found");
        return (QuerySet<TEntity>)set;
    }
    public CommandSet<TEntity> CommandSet<TEntity>() where TEntity : EntityBase
    {
        var typename = typeof(TEntity).Name + "CommandDataStore";
        var set = GetSet(typename);
        if (set == null) throw new ArgumentNullException($"{typename} class object not found");
        return (CommandSet<TEntity>)set;
    }

    public void AddCache(object set)
    {
        var typeName = set.GetType().Name;
        if (!SetCache.ContainsKey(typeName))
        {
            SetCache.Add(typeName, set);
        }
    }

    public object GetSet(string type)
    {
        return SetCache[type];
    }
}
