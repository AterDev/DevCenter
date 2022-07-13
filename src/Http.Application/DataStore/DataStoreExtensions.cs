namespace Http.Application.DataStore;

public static class DataStoreExtensions
{
    public static void AddDataStore(this IServiceCollection services)
    {
        services.AddTransient<IUserContext, UserContext>();
        services.AddScoped(typeof(DataStoreContext));
        services.AddScoped(typeof(CodeFolderDataStore));
        services.AddScoped(typeof(CodeSnippetDataStore));
        services.AddScoped(typeof(ConfigOptionDataStore));
        services.AddScoped(typeof(DocFolderDataStore));
        services.AddScoped(typeof(DocumentDataStore));
        services.AddScoped(typeof(EnvironmentDataStore));
        services.AddScoped(typeof(PermissionDataStore));
        services.AddScoped(typeof(ResourceAttributeDataStore));
        services.AddScoped(typeof(ResourceAttributeDefineDataStore));
        services.AddScoped(typeof(ResourceDataStore));
        services.AddScoped(typeof(ResourceGroupDataStore));
        services.AddScoped(typeof(ResourceTagsDataStore));
        services.AddScoped(typeof(ResourceTypeDefinitionDataStore));
        services.AddScoped(typeof(RoleDataStore));
        services.AddScoped(typeof(RolePermissionDataStore));
        services.AddScoped(typeof(UserDataStore));
    }
}
