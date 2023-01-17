namespace Http.Application.Implement;

public static class StoreServicesExtensions
{
    public static void AddDataStore(this IServiceCollection services)
    {
        _ = services.AddTransient<IUserContext, UserContext>();
        _ = services.AddScoped(typeof(DataStoreContext));
        _ = services.AddScoped(typeof(BlogCatalogQueryStore));
        _ = services.AddScoped(typeof(BlogQueryStore));
        _ = services.AddScoped(typeof(BlogTagQueryStore));
        _ = services.AddScoped(typeof(CodeLibraryQueryStore));
        _ = services.AddScoped(typeof(CodeSnippetQueryStore));
        _ = services.AddScoped(typeof(CommentQueryStore));
        _ = services.AddScoped(typeof(EnvironmentQueryStore));
        _ = services.AddScoped(typeof(ResourceAttributeDefineQueryStore));
        _ = services.AddScoped(typeof(ResourceGroupQueryStore));
        _ = services.AddScoped(typeof(ResourceQueryStore));
        _ = services.AddScoped(typeof(ResourceTagsQueryStore));
        _ = services.AddScoped(typeof(ResourceTypeDefinitionQueryStore));
        _ = services.AddScoped(typeof(RoleQueryStore));
        _ = services.AddScoped(typeof(UserQueryStore));
        _ = services.AddScoped(typeof(BlogCatalogCommandStore));
        _ = services.AddScoped(typeof(BlogCommandStore));
        _ = services.AddScoped(typeof(BlogTagCommandStore));
        _ = services.AddScoped(typeof(CodeLibraryCommandStore));
        _ = services.AddScoped(typeof(CodeSnippetCommandStore));
        _ = services.AddScoped(typeof(CommentCommandStore));
        _ = services.AddScoped(typeof(EnvironmentCommandStore));
        _ = services.AddScoped(typeof(ResourceAttributeDefineCommandStore));
        _ = services.AddScoped(typeof(ResourceCommandStore));
        _ = services.AddScoped(typeof(ResourceGroupCommandStore));
        _ = services.AddScoped(typeof(ResourceTagsCommandStore));
        _ = services.AddScoped(typeof(ResourceTypeDefinitionCommandStore));
        _ = services.AddScoped(typeof(RoleCommandStore));
        _ = services.AddScoped(typeof(UserCommandStore));

    }

    public static void AddManager(this IServiceCollection services)
    {
        _ = services.AddScoped<IBlogCatalogManager, BlogCatalogManager>();
        _ = services.AddScoped<IBlogManager, BlogManager>();
        _ = services.AddScoped<IBlogTagManager, BlogTagManager>();
        _ = services.AddScoped<ICodeLibraryManager, CodeLibraryManager>();
        _ = services.AddScoped<ICodeSnippetManager, CodeSnippetManager>();
        _ = services.AddScoped<ICommentManager, CommentManager>();
        _ = services.AddScoped<IEnvironmentManager, EnvironmentManager>();
        _ = services.AddScoped<IResourceAttributeDefineManager, ResourceAttributeDefineManager>();
        _ = services.AddScoped<IResourceGroupManager, ResourceGroupManager>();
        _ = services.AddScoped<IResourceManager, ResourceManager>();
        _ = services.AddScoped<IResourceTagsManager, ResourceTagsManager>();
        _ = services.AddScoped<IResourceTypeDefinitionManager, ResourceTypeDefinitionManager>();
        _ = services.AddScoped<IRoleManager, RoleManager>();
        _ = services.AddScoped<IUserManager, UserManager>();

    }
}
