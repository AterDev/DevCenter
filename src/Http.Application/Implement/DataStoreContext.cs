namespace Http.Application.Implement;
public class DataStoreContext
{
    public QueryDbContext QueryContext { get; init; }
    public CommandDbContext CommandContext { get; init; }

    public QuerySet<Blog> BlogQuery { get; init; }
    public QuerySet<ResourceAttributeDefine> ResourceAttributeDefineQuery { get; init; }
    public QuerySet<User> UserQuery { get; init; }
    public CommandSet<Blog> BlogCommand { get; init; }
    public CommandSet<ResourceAttributeDefine> ResourceAttributeDefineCommand { get; init; }
    public CommandSet<User> UserCommand { get; init; }


    /// <summary>
    /// 绑在对象
    /// </summary>
    private readonly Dictionary<string, object> SetCache = new();

    public DataStoreContext(
        BlogQueryStore blogQuery,
        ResourceAttributeDefineQueryStore resourceAttributeDefineQuery,
        UserQueryStore userQuery,
        BlogCommandStore blogCommand,
        ResourceAttributeDefineCommandStore resourceAttributeDefineCommand,
        UserCommandStore userCommand,

        QueryDbContext queryDbContext,
        CommandDbContext commandDbContext
    )
    {
        QueryContext = queryDbContext;
        CommandContext = commandDbContext;
        BlogQuery = blogQuery;
        AddCache(BlogQuery);
        ResourceAttributeDefineQuery = resourceAttributeDefineQuery;
        AddCache(ResourceAttributeDefineQuery);
        UserQuery = userQuery;
        AddCache(UserQuery);
        BlogCommand = blogCommand;
        AddCache(BlogCommand);
        ResourceAttributeDefineCommand = resourceAttributeDefineCommand;
        AddCache(ResourceAttributeDefineCommand);
        UserCommand = userCommand;
        AddCache(UserCommand);

    }

    public async Task<int> SaveChangesAsync()
    {
        return await CommandContext.SaveChangesAsync();
    }

    public QuerySet<TEntity> QuerySet<TEntity>() where TEntity : EntityBase
    {
        var typename = typeof(TEntity).Name + "QueryStore";
        var set = GetSet(typename);
        return set == null ? throw new ArgumentNullException($"{typename} class object not found") : (QuerySet<TEntity>)set;
    }
    public CommandSet<TEntity> CommandSet<TEntity>() where TEntity : EntityBase
    {
        var typename = typeof(TEntity).Name + "CommandStore";
        var set = GetSet(typename);
        return set == null ? throw new ArgumentNullException($"{typename} class object not found") : (CommandSet<TEntity>)set;
    }

    private void AddCache(object set)
    {
        var typeName = set.GetType().Name;
        if (!SetCache.ContainsKey(typeName))
        {
            SetCache.Add(typeName, set);
        }
    }

    private object GetSet(string type)
    {
        return SetCache[type];
    }
}
