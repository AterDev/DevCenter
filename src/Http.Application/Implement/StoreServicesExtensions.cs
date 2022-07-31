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
        services.AddScoped(typeof(BlogQueryStore));
        services.AddScoped(typeof(ResourceAttributeDefineQueryStore));
        services.AddScoped(typeof(UserQueryStore));
        services.AddScoped(typeof(BlogCommandStore));
        services.AddScoped(typeof(ResourceAttributeDefineCommandStore));
        services.AddScoped(typeof(UserCommandStore));

    }

    public static void AddManager(this IServiceCollection services)
    {
        services.AddScoped(typeof(BlogManager));
        services.AddScoped(typeof(ResourceAttributeDefineManager));
        services.AddScoped(typeof(UserManager));

    }
}
