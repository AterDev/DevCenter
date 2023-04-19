using Application.CommandStore;
using Application.QueryStore;
using Core.Entities;
using Core.Entities.Blog;
using Core.Entities.Code;
using Core.Entities.GitLab;
using Core.Entities.Resource;
using Share.Models.Webhook.GitLab;
using User = Core.Entities.User;

namespace Application.Implement;
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
    public QuerySet<Environment> EnvironmentQuery { get; init; }
    public QuerySet<GitLabEvent> GitLabCommitQuery { get; init; }
    public QuerySet<GitLabProject> GitLabProjectQuery { get; init; }
    public QuerySet<GitLabUser> GitLabUserQuery { get; init; }
    public QuerySet<ResourceAttributeDefine> ResourceAttributeDefineQuery { get; init; }
    public QuerySet<ResourceGroup> ResourceGroupQuery { get; init; }
    public QuerySet<Resource> ResourceQuery { get; init; }
    public QuerySet<ResourceTags> ResourceTagsQuery { get; init; }
    public QuerySet<ResourceTypeDefinition> ResourceTypeDefinitionQuery { get; init; }
    public QuerySet<Role> RoleQuery { get; init; }
    public QuerySet<User> UserQuery { get; init; }
    public CommandSet<BlogCatalog> BlogCatalogCommand { get; init; }
    public CommandSet<Blog> BlogCommand { get; init; }
    public CommandSet<BlogTag> BlogTagCommand { get; init; }
    public CommandSet<CodeLibrary> CodeLibraryCommand { get; init; }
    public CommandSet<CodeSnippet> CodeSnippetCommand { get; init; }
    public CommandSet<Comment> CommentCommand { get; init; }
    public CommandSet<Environment> EnvironmentCommand { get; init; }
    public CommandSet<GitLabEvent> GitLabCommitCommand { get; init; }
    public CommandSet<GitLabProject> GitLabProjectCommand { get; init; }
    public CommandSet<GitLabUser> GitLabUserCommand { get; init; }
    public CommandSet<ResourceAttributeDefine> ResourceAttributeDefineCommand { get; init; }
    public CommandSet<Resource> ResourceCommand { get; init; }
    public CommandSet<ResourceGroup> ResourceGroupCommand { get; init; }
    public CommandSet<ResourceTags> ResourceTagsCommand { get; init; }
    public CommandSet<ResourceTypeDefinition> ResourceTypeDefinitionCommand { get; init; }
    public CommandSet<Role> RoleCommand { get; init; }
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
        EnvironmentQueryStore environmentQuery,
        GitLabCommitQueryStore gitLabCommitQuery,
        GitLabProjectQueryStore gitLabProjectQuery,
        GitLabUserQueryStore gitLabUserQuery,
        ResourceAttributeDefineQueryStore resourceAttributeDefineQuery,
        ResourceGroupQueryStore resourceGroupQuery,
        ResourceQueryStore resourceQuery,
        ResourceTagsQueryStore resourceTagsQuery,
        ResourceTypeDefinitionQueryStore resourceTypeDefinitionQuery,
        RoleQueryStore roleQuery,
        UserQueryStore userQuery,
        BlogCatalogCommandStore blogCatalogCommand,
        BlogCommandStore blogCommand,
        BlogTagCommandStore blogTagCommand,
        CodeLibraryCommandStore codeLibraryCommand,
        CodeSnippetCommandStore codeSnippetCommand,
        CommentCommandStore commentCommand,
        EnvironmentCommandStore environmentCommand,
        GitLabCommitCommandStore gitLabCommitCommand,
        GitLabProjectCommandStore gitLabProjectCommand,
        GitLabUserCommandStore gitLabUserCommand,
        ResourceAttributeDefineCommandStore resourceAttributeDefineCommand,
        ResourceCommandStore resourceCommand,
        ResourceGroupCommandStore resourceGroupCommand,
        ResourceTagsCommandStore resourceTagsCommand,
        ResourceTypeDefinitionCommandStore resourceTypeDefinitionCommand,
        RoleCommandStore roleCommand,
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
        EnvironmentQuery = environmentQuery;
        AddCache(EnvironmentQuery);
        GitLabCommitQuery = gitLabCommitQuery;
        AddCache(GitLabCommitQuery);
        GitLabProjectQuery = gitLabProjectQuery;
        AddCache(GitLabProjectQuery);
        GitLabUserQuery = gitLabUserQuery;
        AddCache(GitLabUserQuery);
        ResourceAttributeDefineQuery = resourceAttributeDefineQuery;
        AddCache(ResourceAttributeDefineQuery);
        ResourceGroupQuery = resourceGroupQuery;
        AddCache(ResourceGroupQuery);
        ResourceQuery = resourceQuery;
        AddCache(ResourceQuery);
        ResourceTagsQuery = resourceTagsQuery;
        AddCache(ResourceTagsQuery);
        ResourceTypeDefinitionQuery = resourceTypeDefinitionQuery;
        AddCache(ResourceTypeDefinitionQuery);
        RoleQuery = roleQuery;
        AddCache(RoleQuery);
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
        EnvironmentCommand = environmentCommand;
        AddCache(EnvironmentCommand);
        GitLabCommitCommand = gitLabCommitCommand;
        AddCache(GitLabCommitCommand);
        GitLabProjectCommand = gitLabProjectCommand;
        AddCache(GitLabProjectCommand);
        GitLabUserCommand = gitLabUserCommand;
        AddCache(GitLabUserCommand);
        ResourceAttributeDefineCommand = resourceAttributeDefineCommand;
        AddCache(ResourceAttributeDefineCommand);
        ResourceCommand = resourceCommand;
        AddCache(ResourceCommand);
        ResourceGroupCommand = resourceGroupCommand;
        AddCache(ResourceGroupCommand);
        ResourceTagsCommand = resourceTagsCommand;
        AddCache(ResourceTagsCommand);
        ResourceTypeDefinitionCommand = resourceTypeDefinitionCommand;
        AddCache(ResourceTypeDefinitionCommand);
        RoleCommand = roleCommand;
        AddCache(RoleCommand);
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
