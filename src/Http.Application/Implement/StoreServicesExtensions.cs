namespace Http.Application.Implement;

public static class StoreServicesExtensions
{
    public static void AddDataStore(this IServiceCollection services)
    {
        services.AddTransient<IUserContext, UserContext>();
        services.AddScoped(typeof(DataStoreContext));
        services.AddScoped(typeof(BlogCatalogQueryStore));
        services.AddScoped(typeof(BlogQueryStore));
        services.AddScoped(typeof(BlogTagQueryStore));
        services.AddScoped(typeof(CodeLibraryQueryStore));
        services.AddScoped(typeof(CodeSnippetQueryStore));
        services.AddScoped(typeof(CommentQueryStore));
        services.AddScoped(typeof(EnvironmentQueryStore));
        services.AddScoped(typeof(ResourceAttributeDefineQueryStore));
        services.AddScoped(typeof(ResourceGroupQueryStore));
        services.AddScoped(typeof(ResourceQueryStore));
        services.AddScoped(typeof(ResourceTagsQueryStore));
        services.AddScoped(typeof(ResourceTypeDefinitionQueryStore));
        services.AddScoped(typeof(RoleQueryStore));
        services.AddScoped(typeof(UserQueryStore));
        services.AddScoped(typeof(BlogCatalogCommandStore));
        services.AddScoped(typeof(BlogCommandStore));
        services.AddScoped(typeof(BlogTagCommandStore));
        services.AddScoped(typeof(CodeLibraryCommandStore));
        services.AddScoped(typeof(CodeSnippetCommandStore));
        services.AddScoped(typeof(CommentCommandStore));
        services.AddScoped(typeof(EnvironmentCommandStore));
        services.AddScoped(typeof(ResourceAttributeDefineCommandStore));
        services.AddScoped(typeof(ResourceCommandStore));
        services.AddScoped(typeof(ResourceGroupCommandStore));
        services.AddScoped(typeof(ResourceTagsCommandStore));
        services.AddScoped(typeof(ResourceTypeDefinitionCommandStore));
        services.AddScoped(typeof(RoleCommandStore));
        services.AddScoped(typeof(UserCommandStore));

    }

    public static void AddManager(this IServiceCollection services)
    {
        services.AddScoped<IBlogCatalogManager, BlogCatalogManager>();
        services.AddScoped<IBlogManager, BlogManager>();
        services.AddScoped<IBlogTagManager, BlogTagManager>();
        services.AddScoped<ICodeLibraryManager, CodeLibraryManager>();
        services.AddScoped<ICodeSnippetManager, CodeSnippetManager>();
        services.AddScoped<ICommentManager, CommentManager>();
        services.AddScoped<IEnvironmentManager, EnvironmentManager>();
        services.AddScoped<IResourceAttributeDefineManager, ResourceAttributeDefineManager>();
        services.AddScoped<IResourceGroupManager, ResourceGroupManager>();
        services.AddScoped<IResourceManager, ResourceManager>();
        services.AddScoped<IResourceTagsManager, ResourceTagsManager>();
        services.AddScoped<IResourceTypeDefinitionManager, ResourceTypeDefinitionManager>();
        services.AddScoped<IRoleManager, RoleManager>();
        services.AddScoped<IUserManager, UserManager>();

    }
}
