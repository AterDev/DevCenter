using Http.Application.DataStore;
using Http.Application.Manager;

namespace Http.Application.Implement;

public static class StoreServicesExtensions
{
    public static void AddDataStore(this IServiceCollection services)
    {
        services.AddTransient<IUserContext, UserContext>();
        services.AddScoped(typeof(DataStoreContext));
        services.AddScoped(typeof(ConfigOptionDataStore));
        services.AddScoped(typeof(EnvironmentDataStore));
        services.AddScoped(typeof(PermissionDataStore));
        services.AddScoped(typeof(ResourceAttributeDataStore));
        services.AddScoped(typeof(ResourceDataStore));
        services.AddScoped(typeof(ResourceGroupDataStore));
        services.AddScoped(typeof(ResourceTagsDataStore));
        services.AddScoped(typeof(ResourceTypeDefinitionDataStore));
        services.AddScoped(typeof(RoleDataStore));
        services.AddScoped(typeof(RolePermissionDataStore));
        services.AddScoped(typeof(UserDataStore));
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
        services.AddScoped(typeof(UserCommandStore));

    }

    public static void AddManager(this IServiceCollection services)
    {
        services.AddScoped(typeof(BlogCatalogManager));
        services.AddScoped(typeof(BlogManager));
        services.AddScoped(typeof(BlogTagManager));
        services.AddScoped(typeof(CodeLibraryManager));
        services.AddScoped(typeof(CodeSnippetManager));
        services.AddScoped(typeof(CommentManager));
        services.AddScoped(typeof(EnvironmentManager));
        services.AddScoped(typeof(ResourceAttributeDefineManager));
        services.AddScoped(typeof(ResourceGroupManager));
        services.AddScoped(typeof(ResourceManager));
        services.AddScoped(typeof(ResourceTagsManager));
        services.AddScoped(typeof(UserManager));

    }
}
