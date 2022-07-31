namespace Http.Application.Implement;
public class DataStoreContext
{
    public QueryDbContext QueryContext { get; init; }
    public CommandDbContext CommandContext { get; init; }

    public QuerySet<BlogCatalog> BlogCatalogQuery { get; init; }
    public QuerySet<Blog> BlogQuery { get; init; }
    public QuerySet<BlogTag> BlogTagQuery { get; init; }
    public QuerySet<CodeLibrary> CodeLibraryQuery { get; init; }
    public QuerySet<CodeSnippet> CodeSnippetQuery { get; init; }
    public QuerySet<Comment> CommentQuery { get; init; }
    public QuerySet<ResourceAttributeDefine> ResourceAttributeDefineQuery { get; init; }
    public QuerySet<User> UserQuery { get; init; }
    public CommandSet<BlogCatalog> BlogCatalogCommand { get; init; }
    public CommandSet<Blog> BlogCommand { get; init; }
    public CommandSet<BlogTag> BlogTagCommand { get; init; }
    public CommandSet<CodeLibrary> CodeLibraryCommand { get; init; }
    public CommandSet<CodeSnippet> CodeSnippetCommand { get; init; }
    public CommandSet<Comment> CommentCommand { get; init; }
    public CommandSet<ResourceAttributeDefine> ResourceAttributeDefineCommand { get; init; }
    public CommandSet<User> UserCommand { get; init; }


    /// <summary>
    /// 绑在对象
    /// </summary>
    private readonly Dictionary<string, object> SetCache = new();

    public DataStoreContext(
        BlogCatalogQueryStore blogCatalogQuery,
        BlogQueryStore blogQuery,
        BlogTagQueryStore blogTagQuery,
        CodeLibraryQueryStore codeLibraryQuery,
        CodeSnippetQueryStore codeSnippetQuery,
        CommentQueryStore commentQuery,
        ResourceAttributeDefineQueryStore resourceAttributeDefineQuery,
        UserQueryStore userQuery,
        BlogCatalogCommandStore blogCatalogCommand,
        BlogCommandStore blogCommand,
        BlogTagCommandStore blogTagCommand,
        CodeLibraryCommandStore codeLibraryCommand,
        CodeSnippetCommandStore codeSnippetCommand,
        CommentCommandStore commentCommand,
        ResourceAttributeDefineCommandStore resourceAttributeDefineCommand,
        UserCommandStore userCommand,

        QueryDbContext queryDbContext,
        CommandDbContext commandDbContext
    )
    {
        QueryContext = queryDbContext;
        CommandContext = commandDbContext;
        BlogCatalogQuery = blogCatalogQuery;
        AddCache(BlogCatalogQuery);
        BlogQuery = blogQuery;
        AddCache(BlogQuery);
        BlogTagQuery = blogTagQuery;
        AddCache(BlogTagQuery);
        CodeLibraryQuery = codeLibraryQuery;
        AddCache(CodeLibraryQuery);
        CodeSnippetQuery = codeSnippetQuery;
        AddCache(CodeSnippetQuery);
        CommentQuery = commentQuery;
        AddCache(CommentQuery);
        ResourceAttributeDefineQuery = resourceAttributeDefineQuery;
        AddCache(ResourceAttributeDefineQuery);
        UserQuery = userQuery;
        AddCache(UserQuery);
        BlogCatalogCommand = blogCatalogCommand;
        AddCache(BlogCatalogCommand);
        BlogCommand = blogCommand;
        AddCache(BlogCommand);
        BlogTagCommand = blogTagCommand;
        AddCache(BlogTagCommand);
        CodeLibraryCommand = codeLibraryCommand;
        AddCache(CodeLibraryCommand);
        CodeSnippetCommand = codeSnippetCommand;
        AddCache(CodeSnippetCommand);
        CommentCommand = commentCommand;
        AddCache(CommentCommand);
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
        if (set == null) throw new ArgumentNullException($"{typename} class object not found");
        return (QuerySet<TEntity>)set;
    }
    public CommandSet<TEntity> CommandSet<TEntity>() where TEntity : EntityBase
    {
        var typename = typeof(TEntity).Name + "CommandStore";
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
