﻿using Http.Application.DataStore;

namespace Http.Application.Implement;
public class DataStoreContext
{
    public QuerySet<User> UserQuery { get; init; }
    public CommandSet<User> UserCommand { get; init; }

    public QueryDbContext QueryContext { get; init; }
    public CommandDbContext CommandContext { get; init; }

    /// <summary>
    /// 绑在对象
    /// </summary>
    private readonly Dictionary<string, object> SetCache = new();

    public DataStoreContext(
        UserQueryDataStore userQuery,
        UserCommandDataStore userCommand,
        QueryDbContext queryDbContext,
        CommandDbContext commandDbContext
    )
    {
        UserQuery = userQuery;
        UserCommand = userCommand;
        QueryContext = queryDbContext;
        CommandContext = commandDbContext;

        AddCache(UserQuery);
        AddCache(UserCommand);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await CommandContext.SaveChangesAsync();
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